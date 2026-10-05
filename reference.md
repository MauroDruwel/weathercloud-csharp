# Reference
## Auth
<details><summary><code>client.Auth.<a href="/src/WeathercloudApi/Auth/AuthClient.cs">LoginAsync</a>(LoginAuthRequest { ... }) -> WithRawResponseTask</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Authenticates a user session to allow viewing private indoor sensors (`tempin`, `humin`, `heatin`) for the user's station.
This endpoint expects form urlencoded data and returns a `302 Found` redirect on successful login.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Auth.LoginAsync(
    new LoginAuthRequest
    {
        LoginFormEntity = "LoginForm[entity]",
        LoginFormPassword = "LoginForm[password]",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `LoginAuthRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## DeviceLive
<details><summary><code>client.DeviceLive.<a href="/src/WeathercloudApi/DeviceLive/DeviceLiveClient.cs">GetValuesAsync</a>(GetValuesDeviceLiveRequest { ... }) -> WithRawResponseTask&lt;DeviceValues&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns the latest sensor values for a device. **No CSRF token needed.**
This is the primary endpoint for a Home Assistant sensor integration.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.DeviceLive.GetValuesAsync(new GetValuesDeviceLiveRequest { DeviceId = "5726468552" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetValuesDeviceLiveRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.DeviceLive.<a href="/src/WeathercloudApi/DeviceLive/DeviceLiveClient.cs">GetStatsAsync</a>(GetStatsDeviceLiveRequest { ... }) -> WithRawResponseTask&lt;DeviceStats&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns current values plus day/month/year min and max for all sensors.
Each value is a `[unix_timestamp, value]` tuple.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.DeviceLive.GetStatsAsync(new GetStatsDeviceLiveRequest { Code = "5726468552" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetStatsDeviceLiveRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.DeviceLive.<a href="/src/WeathercloudApi/DeviceLive/DeviceLiveClient.cs">GetInfoAsync</a>(GetInfoDeviceLiveRequest { ... }) -> WithRawResponseTask&lt;DeviceInfo&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Station name, location, elevation, equipment info.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.DeviceLive.GetInfoAsync(new GetInfoDeviceLiveRequest { DeviceId = "5726468552" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetInfoDeviceLiveRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.DeviceLive.<a href="/src/WeathercloudApi/DeviceLive/DeviceLiveClient.cs">GetWindRoseAsync</a>(GetWindRoseDeviceLiveRequest { ... }) -> WithRawResponseTask&lt;WindData&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Wind direction distribution data for the wind rose chart.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.DeviceLive.GetWindRoseAsync(new GetWindRoseDeviceLiveRequest { Code = "5726468552" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetWindRoseDeviceLiveRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.DeviceLive.<a href="/src/WeathercloudApi/DeviceLive/DeviceLiveClient.cs">GetUpdateStatusAsync</a>(GetUpdateStatusDeviceLiveRequest { ... }) -> WithRawResponseTask&lt;GetUpdateStatusDeviceLiveResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns seconds since last update and device online status.

> ⚠️ **Requires `X-Requested-With: XMLHttpRequest`** header — without it the server returns an empty 200.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.DeviceLive.GetUpdateStatusAsync(
    new GetUpdateStatusDeviceLiveRequest { D = "5726468552" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetUpdateStatusDeviceLiveRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.DeviceLive.<a href="/src/WeathercloudApi/DeviceLive/DeviceLiveClient.cs">GetOwnerProfileAsync</a>(GetOwnerProfileDeviceLiveRequest { ... }) -> WithRawResponseTask&lt;DeviceProfile&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns observer name, follower count, and device brand/model.

> ⚠️ **Requires `X-Requested-With: XMLHttpRequest`** header — without it the server returns an empty 200.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.DeviceLive.GetOwnerProfileAsync(
    new GetOwnerProfileDeviceLiveRequest { D = "5726468552" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetOwnerProfileDeviceLiveRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## DeviceHistory
<details><summary><code>client.DeviceHistory.<a href="/src/WeathercloudApi/DeviceHistory/DeviceHistoryClient.cs">GetEvolutionAsync</a>(GetEvolutionDeviceHistoryRequest { ... }) -> WithRawResponseTask&lt;EvolutionResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns hourly aggregated history for a given variable and period.

> ⚠️ **Requires `X-Requested-With: XMLHttpRequest`** header — without it the server returns an empty 200.

**Variable codes:**
| Code | Sensor |
|------|--------|
| 101  | Temperature (°C) |
| 201  | Humidity (%) |
| 541  | Dew point (°C) |
| 641  | Barometric pressure (hPa) |
| 701  | Wind speed (m/s) |
| 6001 | Wind direction (°) |
| 6501 | Wind gust / high speed (m/s) |
| 801  | Rain (mm) |
| 811  | Rain rate (mm/h) |
| 1001 | Solar radiation (W/m²) |
| 1101 | UV index |

**Period values:** `day`, `week`, `month`, `year`
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.DeviceHistory.GetEvolutionAsync(
    new GetEvolutionDeviceHistoryRequest
    {
        Device = "5726468552",
        Variable = 101,
        Period = GetEvolutionDeviceHistoryRequestPeriod.Day,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetEvolutionDeviceHistoryRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Forecast
<details><summary><code>client.Forecast.<a href="/src/WeathercloudApi/Forecast/ForecastClient.cs">GetDailyAsync</a>(GetDailyForecastRequest { ... }) -> WithRawResponseTask&lt;ForecastResponse&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Forecast.GetDailyAsync(new GetDailyForecastRequest { Id = "5726468552" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetDailyForecastRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Map
<details><summary><code>client.Map.<a href="/src/WeathercloudApi/Map/MapClient.cs">GetDevicesAsync</a>(GetDevicesMapRequest { ... }) -> WithRawResponseTask&lt;MapDevicesResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns stations visible on the map for a given location bounding box.

> ⚠️ **Requires `X-Requested-With: XMLHttpRequest`** header — without it the server returns an empty 200.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Map.GetDevicesAsync(new GetDevicesMapRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetDevicesMapRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Map.<a href="/src/WeathercloudApi/Map/MapClient.cs">GetBackgroundDevicesAsync</a>(GetBackgroundDevicesMapRequest { ... }) -> WithRawResponseTask&lt;MapDevicesResponse&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Map.GetBackgroundDevicesAsync(new GetBackgroundDevicesMapRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetBackgroundDevicesMapRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Map.<a href="/src/WeathercloudApi/Map/MapClient.cs">GetMetarsAsync</a>(Dictionary&lt;string, object?&gt; { ... }) -> WithRawResponseTask&lt;GetMetarsMapResponse&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Map.GetMetarsAsync(new Dictionary<string, object?>() { { "key", "value" } });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `Dictionary<string, object?>` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Stations
<details><summary><code>client.Stations.<a href="/src/WeathercloudApi/Stations/StationsClient.cs">GetNearbyAsync</a>(GetNearbyStationsRequest { ... }) -> WithRawResponseTask&lt;PageDevicesResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns nearby stations as JSON (despite `text/html` content-type header).
All `page/*` endpoints return `PageDevice` objects that include the **station name**.
Values are scaled integers — divide by 10 (e.g. `temp: 281` = 28.1°C).
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Stations.GetNearbyAsync(
    new GetNearbyStationsRequest
    {
        Lat = 1.1,
        Lon = 1.1,
        Km = 1,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetNearbyStationsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Stations.<a href="/src/WeathercloudApi/Stations/StationsClient.cs">GetPopularAsync</a>(GetPopularStationsRequest { ... }) -> WithRawResponseTask&lt;PageDevicesResponse&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Stations.GetPopularAsync(
    new GetPopularStationsRequest { Country = "BE", Period = GetPopularStationsRequestPeriod.Day }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetPopularStationsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Stations.<a href="/src/WeathercloudApi/Stations/StationsClient.cs">GetNewestAsync</a>(GetNewestStationsRequest { ... }) -> WithRawResponseTask&lt;PageDevicesResponse&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Stations.GetNewestAsync(new GetNewestStationsRequest { Country = "BE" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetNewestStationsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Stations.<a href="/src/WeathercloudApi/Stations/StationsClient.cs">GetMostFollowedAsync</a>(GetMostFollowedStationsRequest { ... }) -> WithRawResponseTask&lt;PageDevicesResponse&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Stations.GetMostFollowedAsync(new GetMostFollowedStationsRequest { Country = "BE" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetMostFollowedStationsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Stations.<a href="/src/WeathercloudApi/Stations/StationsClient.cs">GetLastViewsAsync</a>() -> WithRawResponseTask&lt;PageDevicesResponse&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Stations.GetLastViewsAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Stations.<a href="/src/WeathercloudApi/Stations/StationsClient.cs">GetOwnAsync</a>() -> WithRawResponseTask&lt;PageDevicesResponse&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Stations.GetOwnAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Stations.<a href="/src/WeathercloudApi/Stations/StationsClient.cs">GetStationPageAsync</a>(GetStationPageStationsRequest { ... }) -> WithRawResponseTask&lt;string&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

The station **name** is not available from any JSON API endpoint.
The easiest way to get it is to fetch the station's HTML page and extract
the name from the `<title>` or `og:title` meta tag.

**Example response title:**
```
WeatherStation Skyline - Weathercloud | Global network of weather stations
```

Strip everything from ` - Weathercloud` onward to get the clean station name.

> This is a plain HTML page, not a JSON API. Use it for scraping only.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Stations.GetStationPageAsync(
    new GetStationPageStationsRequest { DeviceId = "deviceId" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetStationPageStationsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Metar
<details><summary><code>client.Metar.<a href="/src/WeathercloudApi/Metar/MetarClient.cs">GetValuesAsync</a>(GetValuesMetarRequest { ... }) -> WithRawResponseTask&lt;DeviceValues&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Most `device/*` routes work identically for METAR (airport) stations by replacing the `device` prefix with `metar`.

METAR station IDs are **ICAO codes** (4 letters), e.g. `EBBR` for Brussels Airport.

**Supported `metar/*` routes (same request/response as their `device/*` counterparts):**
- `GET /metar/values/{icao}` — current readings
- `GET /metar/stats?code={icao}` — statistics
- `GET /metar/wind?code={icao}` — wind rose
- `GET /metar/info/{icao}` — station metadata
- `POST /metar/ajaxupdatedate` — last update time
- `POST /metar/ajaxprofile` — station profile
- `POST /metar/evolution` — time-series history

> **Not supported for METAR:** `/device/ajaxdevicestats`
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Metar.GetValuesAsync(new GetValuesMetarRequest { DeviceId = "EBBR" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetValuesMetarRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

