namespace WeathercloudApi;

public partial interface IDeviceHistoryClient
{
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
    WithRawResponseTask<EvolutionResponse> GetEvolutionAsync(
        GetEvolutionDeviceHistoryRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
