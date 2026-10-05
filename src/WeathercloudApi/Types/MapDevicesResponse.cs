using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using WeathercloudApi.Core;

namespace WeathercloudApi;

/// <summary>
/// Stations as compact arrays. Also contains `owner` and `favorites` arrays (empty unless logged in).
/// </summary>
[Serializable]
public record MapDevicesResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Each entry is an array:
    /// `[id, city, lat, lon, status, 0, temp×10, hum, bar×10, wspd×10, wdir, rainrate×10, rain×10, solarrad×10, uvi×10]`
    ///
    /// - `status`: 1=online, 2=recently online, 3=offline
    /// - Divide index 6 and above by 10 to get real units
    /// </summary>
    [JsonPropertyName("devices")]
    public IEnumerable<IEnumerable<object>>? Devices { get; set; }

    /// <summary>
    /// Owner's own stations (empty if not logged in)
    /// </summary>
    [JsonPropertyName("owner")]
    public IEnumerable<IEnumerable<object>>? Owner { get; set; }

    /// <summary>
    /// Favourite stations (empty if not logged in)
    /// </summary>
    [JsonPropertyName("favorites")]
    public IEnumerable<IEnumerable<object>>? Favorites { get; set; }

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
