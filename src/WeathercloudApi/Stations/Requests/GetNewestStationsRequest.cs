using global::System.Text.Json.Serialization;
using WeathercloudApi.Core;

namespace WeathercloudApi;

[Serializable]
public record GetNewestStationsRequest
{
    [JsonIgnore]
    public required string Country { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
