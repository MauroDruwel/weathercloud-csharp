using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Weathercloud.Core;

namespace Weathercloud;

[Serializable]
public record EvolutionResponseDataValuesValueValue : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("samples")]
    public int? Samples { get; set; }

    [JsonPropertyName("stats")]
    public EvolutionResponseDataValuesValueValueStats? Stats { get; set; }

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
