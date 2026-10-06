using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Weathercloud.Core;

namespace Weathercloud;

[Serializable]
public record GetMetarsMapResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Each entry: `[icao, city, lat, lon, status, 0, wdir, hum, bar*10, wspd*10, wdir2, 0, "", "", ""]`
    /// </summary>
    [JsonPropertyName("metars")]
    public IEnumerable<IEnumerable<object>>? Metars { get; set; }

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
