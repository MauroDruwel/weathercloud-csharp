namespace Weathercloud;

public partial interface IWeathercloudClient
{
    public IAuthClient Auth { get; }
    public IDeviceLiveClient DeviceLive { get; }
    public IDeviceHistoryClient DeviceHistory { get; }
    public IForecastClient Forecast { get; }
    public IMapClient Map { get; }
    public IStationsClient Stations { get; }
    public IMetarClient Metar { get; }
}
