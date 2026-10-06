using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Weathercloud.Core;

namespace Weathercloud;

[Serializable]
public record EvolutionResponseData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("timezone")]
    public string? Timezone { get; set; }

    /// <summary>
    /// Keyed by variable code (e.g. "101")
    /// </summary>
    [JsonPropertyName("summary")]
    public Dictionary<string, EvolutionResponseDataSummaryValue>? Summary { get; set; }

    /// <summary>
    /// Keyed by Unix timestamp (hour buckets), then by variable code.
    /// Each entry has `samples` and `stats`.
    /// </summary>
    [JsonPropertyName("values")]
    public Dictionary<
        string,
        Dictionary<string, EvolutionResponseDataValuesValueValue>
    >? Values { get; set; }

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
