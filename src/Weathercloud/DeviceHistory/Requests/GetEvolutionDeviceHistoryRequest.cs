using global::System.Text.Json.Serialization;
using Weathercloud.Core;

namespace Weathercloud;

[Serializable]
public record GetEvolutionDeviceHistoryRequest
{
    [JsonPropertyName("device")]
    public required string Device { get; set; }

    [JsonPropertyName("variable")]
    public required int Variable { get; set; }

    [JsonPropertyName("period")]
    public required GetEvolutionDeviceHistoryRequestPeriod Period { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
