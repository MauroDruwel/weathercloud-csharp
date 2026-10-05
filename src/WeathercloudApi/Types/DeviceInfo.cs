using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using WeathercloudApi.Core;

namespace WeathercloudApi;

/// <summary>
/// Station metadata and current sensor snapshot.
/// Note: sensor values are returned as strings; unavailable sensors show `-3276.8` / `-32768`.
/// </summary>
[Serializable]
public record DeviceInfo : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("device")]
    public DeviceInfoDevice? Device { get; set; }

    /// <summary>
    /// Current sensor readings as strings.
    /// Unavailable sensors return `"-3276.8"` (float sensors) or `"-32768"` (integer sensors).
    /// </summary>
    [JsonPropertyName("values")]
    public DeviceInfoValues? Values { get; set; }

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
