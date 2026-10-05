using global::System.Text.Json;
using WeathercloudApi.Core;

namespace WeathercloudApi;

public partial class MetarClient : IMetarClient
{
    private readonly RawClient _client;

    internal MetarClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<DeviceValues>> GetValuesAsyncCore(
        GetValuesMetarRequest request,
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
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "metar/values/{0}",
                        ValueConvert.ToPathParameterString(request.DeviceId)
                    ),
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
                var responseData = JsonUtils.Deserialize<DeviceValues>(responseBody)!;
                return new WithRawResponse<DeviceValues>()
                {
                    Data = responseData,
                    RawResponse = new WeathercloudApi.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new WeathercloudApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e,
                    rawResponse: new WeathercloudApi.RawResponse()
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
    /// Most `device/*` routes work identically for METAR (airport) stations by replacing the `device` prefix with `metar`.
    ///
    /// METAR station IDs are **ICAO codes** (4 letters), e.g. `EBBR` for Brussels Airport.
    ///
    /// **Supported `metar/*` routes (same request/response as their `device/*` counterparts):**
    /// - `GET /metar/values/{icao}` — current readings
    /// - `GET /metar/stats?code={icao}` — statistics
    /// - `GET /metar/wind?code={icao}` — wind rose
    /// - `GET /metar/info/{icao}` — station metadata
    /// - `POST /metar/ajaxupdatedate` — last update time
    /// - `POST /metar/ajaxprofile` — station profile
    /// - `POST /metar/evolution` — time-series history
    ///
    /// &gt; **Not supported for METAR:** `/device/ajaxdevicestats`
    /// </summary>
    /// <example><code>
    /// await client.Metar.GetValuesAsync(new GetValuesMetarRequest { DeviceId = "EBBR" });
    /// </code></example>
    public WithRawResponseTask<DeviceValues> GetValuesAsync(
        GetValuesMetarRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<DeviceValues>(
            GetValuesAsyncCore(request, options, cancellationToken)
        );
    }
}
