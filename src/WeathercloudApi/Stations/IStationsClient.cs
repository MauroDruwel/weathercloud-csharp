namespace WeathercloudApi;

public partial interface IStationsClient
{
    /// <summary>
    /// Returns nearby stations as JSON (despite `text/html` content-type header).
    /// All `page/*` endpoints return `PageDevice` objects that include the **station name**.
    /// Values are scaled integers — divide by 10 (e.g. `temp: 281` = 28.1°C).
    /// </summary>
    WithRawResponseTask<PageDevicesResponse> GetNearbyAsync(
        GetNearbyStationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<PageDevicesResponse> GetPopularAsync(
        GetPopularStationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<PageDevicesResponse> GetNewestAsync(
        GetNewestStationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<PageDevicesResponse> GetMostFollowedAsync(
        GetMostFollowedStationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<PageDevicesResponse> GetLastViewsAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<PageDevicesResponse> GetOwnAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// The station **name** is not available from any JSON API endpoint.
    /// The easiest way to get it is to fetch the station's HTML page and extract
    /// the name from the `&lt;title&gt;` or `og:title` meta tag.
    ///
    /// **Example response title:**
    /// ```
    /// WeatherStation Skyline - Weathercloud | Global network of weather stations
    /// ```
    ///
    /// Strip everything from ` - Weathercloud` onward to get the clean station name.
    ///
    /// &gt; This is a plain HTML page, not a JSON API. Use it for scraping only.
    /// </summary>
    WithRawResponseTask<string> GetStationPageAsync(
        GetStationPageStationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
