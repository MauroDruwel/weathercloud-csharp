namespace WeathercloudApi;

public partial interface IDeviceLiveClient
{
    /// <summary>
    /// Returns the latest sensor values for a device. **No CSRF token needed.**
    /// This is the primary endpoint for a Home Assistant sensor integration.
    /// </summary>
    WithRawResponseTask<DeviceValues> GetValuesAsync(
        GetValuesDeviceLiveRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns current values plus day/month/year min and max for all sensors.
    /// Each value is a `[unix_timestamp, value]` tuple.
    /// </summary>
    WithRawResponseTask<DeviceStats> GetStatsAsync(
        GetStatsDeviceLiveRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Station name, location, elevation, equipment info.
    /// </summary>
    WithRawResponseTask<DeviceInfo> GetInfoAsync(
        GetInfoDeviceLiveRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Wind direction distribution data for the wind rose chart.
    /// </summary>
    WithRawResponseTask<WindData> GetWindRoseAsync(
        GetWindRoseDeviceLiveRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns seconds since last update and device online status.
    ///
    /// &gt; ⚠️ **Requires `X-Requested-With: XMLHttpRequest`** header — without it the server returns an empty 200.
    /// </summary>
    WithRawResponseTask<GetUpdateStatusDeviceLiveResponse> GetUpdateStatusAsync(
        GetUpdateStatusDeviceLiveRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns observer name, follower count, and device brand/model.
    ///
    /// &gt; ⚠️ **Requires `X-Requested-With: XMLHttpRequest`** header — without it the server returns an empty 200.
    /// </summary>
    WithRawResponseTask<DeviceProfile> GetOwnerProfileAsync(
        GetOwnerProfileDeviceLiveRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
