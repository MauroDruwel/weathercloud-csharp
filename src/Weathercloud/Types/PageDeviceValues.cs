using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Weathercloud.Core;

namespace Weathercloud;

/// <summary>
/// Scaled integer sensor readings — divide by 10 for most values.
/// e.g. `temp: 281` → 28.1°C, `bar: 10247` → 1024.7 hPa, `uvi: 70` → UV 7.0
/// </summary>
[Serializable]
public record PageDeviceValues : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("epoch")]
    public string? Epoch { get; set; }

    [JsonPropertyName("temp")]
    public string? Temp { get; set; }

    [JsonPropertyName("hum")]
    public string? Hum { get; set; }

    [JsonPropertyName("dew")]
    public string? Dew { get; set; }

    [JsonPropertyName("chill")]
    public string? Chill { get; set; }

    [JsonPropertyName("heat")]
    public string? Heat { get; set; }

    [JsonPropertyName("bar")]
    public string? Bar { get; set; }

    [JsonPropertyName("wdir")]
    public string? Wdir { get; set; }

    [JsonPropertyName("wspd")]
    public string? Wspd { get; set; }

    [JsonPropertyName("wspdavg")]
    public string? Wspdavg { get; set; }

    [JsonPropertyName("wspdhi")]
    public string? Wspdhi { get; set; }

    [JsonPropertyName("rainrate")]
    public string? Rainrate { get; set; }

    [JsonPropertyName("rain")]
    public string? Rain { get; set; }

    [JsonPropertyName("solarrad")]
    public string? Solarrad { get; set; }

    [JsonPropertyName("uvi")]
    public string? Uvi { get; set; }

    /// <summary>
    /// Indoor temperature (°C, scaled ×10) — if sensor present
    /// </summary>
    [JsonPropertyName("tempin")]
    public string? Tempin { get; set; }

    /// <summary>
    /// Indoor humidity (%, scaled ×10) — if sensor present
    /// </summary>
    [JsonPropertyName("humin")]
    public string? Humin { get; set; }

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
