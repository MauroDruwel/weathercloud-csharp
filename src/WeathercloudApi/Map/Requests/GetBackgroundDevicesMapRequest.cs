using global::System.Text.Json.Serialization;
using WeathercloudApi.Core;

namespace WeathercloudApi;

[Serializable]
public record GetBackgroundDevicesMapRequest
{
    [JsonPropertyName("user")]
    public string? User { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
