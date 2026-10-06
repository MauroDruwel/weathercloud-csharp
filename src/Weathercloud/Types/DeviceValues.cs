using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Weathercloud.Core;

namespace Weathercloud;

/// <summary>
/// Live sensor readings
/// </summary>
[Serializable]
public record DeviceValues : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unix timestamp of reading
    /// </summary>
    [JsonPropertyName("epoch")]
    public int? Epoch { get; set; }

    /// <summary>
    /// Temperature (°C)
    /// </summary>
    [JsonPropertyName("temp")]
    public double? Temp { get; set; }

    /// <summary>
    /// Dew point (°C)
    /// </summary>
    [JsonPropertyName("dew")]
    public double? Dew { get; set; }

    /// <summary>
    /// Wind chill (°C)
    /// </summary>
    [JsonPropertyName("chill")]
    public double? Chill { get; set; }

    /// <summary>
    /// Heat index (°C)
    /// </summary>
    [JsonPropertyName("heat")]
    public double? Heat { get; set; }

    /// <summary>
    /// Relative humidity (%)
    /// </summary>
    [JsonPropertyName("hum")]
    public int? Hum { get; set; }

    /// <summary>
    /// Barometric pressure (hPa)
    /// </summary>
    [JsonPropertyName("bar")]
    public double? Bar { get; set; }

    /// <summary>
    /// Instantaneous wind direction (°)
    /// </summary>
    [JsonPropertyName("wdir")]
    public int? Wdir { get; set; }

    /// <summary>
    /// Average wind direction (°)
    /// </summary>
    [JsonPropertyName("wdiravg")]
    public int? Wdiravg { get; set; }

    /// <summary>
    /// Instantaneous wind speed (m/s)
    /// </summary>
    [JsonPropertyName("wspd")]
    public double? Wspd { get; set; }

    /// <summary>
    /// Average wind speed (m/s)
    /// </summary>
    [JsonPropertyName("wspdavg")]
    public double? Wspdavg { get; set; }

    /// <summary>
    /// Wind gust / high speed (m/s)
    /// </summary>
    [JsonPropertyName("wspdhi")]
    public double? Wspdhi { get; set; }

    /// <summary>
    /// Rain rate (mm/h)
    /// </summary>
    [JsonPropertyName("rainrate")]
    public double? Rainrate { get; set; }

    /// <summary>
    /// Total rain (mm)
    /// </summary>
    [JsonPropertyName("rain")]
    public double? Rain { get; set; }

    /// <summary>
    /// Solar radiation (W/m²)
    /// </summary>
    [JsonPropertyName("solarrad")]
    public double? Solarrad { get; set; }

    /// <summary>
    /// UV index (standard units, not ×10 — can be fractional, e.g. 0.9)
    /// </summary>
    [JsonPropertyName("uvi")]
    public double? Uvi { get; set; }

    /// <summary>
    /// Inside temperature (°C) — requires authentication
    /// </summary>
    [JsonPropertyName("tempin")]
    public double? Tempin { get; set; }

    /// <summary>
    /// Inside relative humidity (%) — requires authentication
    /// </summary>
    [JsonPropertyName("humin")]
    public int? Humin { get; set; }

    /// <summary>
    /// Inside heat index (°C) — requires authentication
    /// </summary>
    [JsonPropertyName("heatin")]
    public double? Heatin { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
