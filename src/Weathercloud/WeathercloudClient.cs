using Weathercloud.Core;

namespace Weathercloud;

public partial class WeathercloudClient : IWeathercloudClient
{
    private readonly RawClient _client;

    public WeathercloudClient(string? requestedWith = null, ClientOptions? clientOptions = null)
    {
        clientOptions ??= new ClientOptions();
        var platformHeaders = new Headers(
            new Dictionary<string, string>()
            {
                { "X-Fern-Language", "C#" },
                { "X-Fern-SDK-Name", "Weathercloud" },
                { "X-Fern-SDK-Version", global::Weathercloud.Version.Current },
            }
        );
        foreach (var header in platformHeaders)
        {
            if (!clientOptions.Headers.ContainsKey(header.Key))
            {
                clientOptions.Headers[header.Key] = header.Value;
            }
        }
        var clientOptionsWithAuth = clientOptions.Clone();
        var authHeaders = new Headers(
            new Dictionary<string, string>() { { "X-Requested-With", requestedWith ?? "" } }
        );
        foreach (var header in authHeaders)
        {
            clientOptionsWithAuth.Headers[header.Key] = header.Value;
        }
        _client = new RawClient(clientOptionsWithAuth);
        Auth = new AuthClient(_client);
        DeviceLive = new DeviceLiveClient(_client);
        DeviceHistory = new DeviceHistoryClient(_client);
        Forecast = new ForecastClient(_client);
        Map = new MapClient(_client);
        Stations = new StationsClient(_client);
        Metar = new MetarClient(_client);
    }

    public IAuthClient Auth { get; }

    public IDeviceLiveClient DeviceLive { get; }

    public IDeviceHistoryClient DeviceHistory { get; }

    public IForecastClient Forecast { get; }

    public IMapClient Map { get; }

    public IStationsClient Stations { get; }

    public IMetarClient Metar { get; }
}
