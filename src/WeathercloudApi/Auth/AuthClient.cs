using WeathercloudApi.Core;

namespace WeathercloudApi;

public partial class AuthClient : IAuthClient
{
    private readonly RawClient _client;

    internal AuthClient(RawClient client)
    {
        _client = client;
    }

    private async Task<RawResponse> LoginAsyncCore(
        LoginAuthRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new WeathercloudApi.Core.QueryStringBuilder.Builder(capacity: 0)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new WeathercloudApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new FormRequest
                {
                    Method = HttpMethod.Post,
                    Path = "signin",
                    Body = request,
                    QueryString = _queryString,
                    Headers = _headers,
                    ContentType = "application/x-www-form-urlencoded",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            return new WeathercloudApi.RawResponse()
            {
                StatusCode = response.Raw.StatusCode,
                Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
            };
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            throw new WeathercloudApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody,
                rawResponse: new WeathercloudApi.RawResponse()
                {
                    StatusCode = response.Raw.StatusCode,
                    Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                    Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                }
            );
        }
    }

    /// <summary>
    /// Authenticates a user session to allow viewing private indoor sensors (`tempin`, `humin`, `heatin`) for the user's station.
    /// This endpoint expects form urlencoded data and returns a `302 Found` redirect on successful login.
    /// </summary>
    /// <example><code>
    /// await client.Auth.LoginAsync(
    ///     new LoginAuthRequest
    ///     {
    ///         LoginFormEntity = "LoginForm[entity]",
    ///         LoginFormPassword = "LoginForm[password]",
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask LoginAsync(
        LoginAuthRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask(LoginAsyncCore(request, options, cancellationToken));
    }
}
