namespace Weathercloud;

public partial interface IMapClient
{
    /// <summary>
    /// Returns stations visible on the map for a given location bounding box.
    ///
    /// &gt; ⚠️ **Requires `X-Requested-With: XMLHttpRequest`** header — without it the server returns an empty 200.
    /// </summary>
    WithRawResponseTask<MapDevicesResponse> GetDevicesAsync(
        GetDevicesMapRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<MapDevicesResponse> GetBackgroundDevicesAsync(
        GetBackgroundDevicesMapRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<GetMetarsMapResponse> GetMetarsAsync(
        Dictionary<string, object?> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
