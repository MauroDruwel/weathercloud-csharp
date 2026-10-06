using global::System.Text.Json;
using Weathercloud.Core;

namespace Weathercloud;

public partial class DeviceHistoryClient : IDeviceHistoryClient
{
    private readonly RawClient _client;

    internal DeviceHistoryClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<EvolutionResponse>> GetEvolutionAsyncCore(
        GetEvolutionDeviceHistoryRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Weathercloud.Core.QueryStringBuilder.Builder(capacity: 0)
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
                new FormRequest
                {
                    Method = HttpMethod.Post,
                    Path = "device/evolution",
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
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<EvolutionResponse>(responseBody)!;
                return new WithRawResponse<EvolutionResponse>()
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

    /// <summary>
    /// Returns hourly aggregated history for a given variable and period.
    ///
    /// &gt; ⚠️ **Requires `X-Requested-With: XMLHttpRequest`** header — without it the server returns an empty 200.
    ///
    /// **Variable codes:**
    /// | Code | Sensor |
    /// |------|--------|
    /// | 101  | Temperature (°C) |
    /// | 201  | Humidity (%) |
    /// | 541  | Dew point (°C) |
    /// | 641  | Barometric pressure (hPa) |
    /// | 701  | Wind speed (m/s) |
    /// | 6001 | Wind direction (°) |
    /// | 6501 | Wind gust / high speed (m/s) |
    /// | 801  | Rain (mm) |
    /// | 811  | Rain rate (mm/h) |
    /// | 1001 | Solar radiation (W/m²) |
    /// | 1101 | UV index |
    ///
    /// **Period values:** `day`, `week`, `month`, `year`
    /// </summary>
    /// <example><code>
    /// await client.DeviceHistory.GetEvolutionAsync(
    ///     new GetEvolutionDeviceHistoryRequest
    ///     {
    ///         Device = "5726468552",
    ///         Variable = 101,
    ///         Period = GetEvolutionDeviceHistoryRequestPeriod.Day,
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<EvolutionResponse> GetEvolutionAsync(
        GetEvolutionDeviceHistoryRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<EvolutionResponse>(
            GetEvolutionAsyncCore(request, options, cancellationToken)
        );
    }
}
