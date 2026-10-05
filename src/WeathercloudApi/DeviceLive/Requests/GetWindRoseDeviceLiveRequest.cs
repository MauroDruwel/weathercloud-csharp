using global::System.Text.Json.Serialization;
using WeathercloudApi.Core;

namespace WeathercloudApi;

[Serializable]
public record GetWindRoseDeviceLiveRequest
{
    [JsonIgnore]
    public required string Code { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
