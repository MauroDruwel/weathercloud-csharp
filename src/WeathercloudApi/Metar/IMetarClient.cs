namespace WeathercloudApi;

public partial interface IMetarClient
{
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
    WithRawResponseTask<DeviceValues> GetValuesAsync(
        GetValuesMetarRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
