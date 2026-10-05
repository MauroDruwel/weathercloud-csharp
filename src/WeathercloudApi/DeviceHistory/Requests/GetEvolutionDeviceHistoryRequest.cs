using global::System.Text.Json.Serialization;
using WeathercloudApi.Core;

namespace WeathercloudApi;

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
