using global::System.Text.Json;
using Weathercloud.Core;

namespace Weathercloud;

public partial class ForecastClient : IForecastClient
{
    private readonly RawClient _client;

    internal ForecastClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<ForecastResponse>> GetDailyAsyncCore(
        GetDailyForecastRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Weathercloud.Core.QueryStringBuilder.Builder(capacity: 1)
            .Add("id", request.Id)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new Weathercloud.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "forecast/daily",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<ForecastResponse>(responseBody)!;
                return new WithRawResponse<ForecastResponse>()
                {
                    Data = responseData,
                    RawResponse = new Weathercloud.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new WeathercloudClientApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e,
                    rawResponse: new Weathercloud.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    }
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            throw new WeathercloudClientApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody,
                rawResponse: new Weathercloud.RawResponse()
                {
                    StatusCode = response.Raw.StatusCode,
                    Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                    Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                }
            );
        }
    }

    /// <example><code>
    /// await client.Forecast.GetDailyAsync(new GetDailyForecastRequest { Id = "5726468552" });
    /// </code></example>
    public WithRawResponseTask<ForecastResponse> GetDailyAsync(
        GetDailyForecastRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ForecastResponse>(
            GetDailyAsyncCore(request, options, cancellationToken)
        );
    }
}
