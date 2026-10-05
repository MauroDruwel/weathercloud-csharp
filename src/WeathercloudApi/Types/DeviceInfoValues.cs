using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using WeathercloudApi.Core;

namespace WeathercloudApi;

/// <summary>
/// Current sensor readings as strings.
/// Unavailable sensors return `"-3276.8"` (float sensors) or `"-32768"` (integer sensors).
/// </summary>
[Serializable]
public record DeviceInfoValues : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Temperature (°C)
    /// </summary>
    [JsonPropertyName("temp")]
    public string? Temp { get; set; }

    /// <summary>
    /// Relative humidity (%)
    /// </summary>
    [JsonPropertyName("hum")]
    public string? Hum { get; set; }

    /// <summary>
    /// Dew point (°C)
    /// </summary>
    [JsonPropertyName("dew")]
    public string? Dew { get; set; }

    /// <summary>
    /// Average wind speed (m/s)
    /// </summary>
    [JsonPropertyName("wspdavg")]
    public string? Wspdavg { get; set; }

    /// <summary>
    /// Average wind direction (°)
    /// </summary>
    [JsonPropertyName("wdiravg")]
    public string? Wdiravg { get; set; }

    /// <summary>
    /// Barometric pressure (hPa)
    /// </summary>
    [JsonPropertyName("bar")]
    public string? Bar { get; set; }

    /// <summary>
    /// Total rain (mm)
    /// </summary>
    [JsonPropertyName("rain")]
    public string? Rain { get; set; }

    /// <summary>
    /// Rain rate (mm/h)
    /// </summary>
    [JsonPropertyName("rainrate")]
    public string? Rainrate { get; set; }

    /// <summary>
    /// Solar radiation (W/m²)
    /// </summary>
    [JsonPropertyName("solarrad")]
    public string? Solarrad { get; set; }

    /// <summary>
    /// UV index
    /// </summary>
    [JsonPropertyName("uvi")]
    public string? Uvi { get; set; }

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
