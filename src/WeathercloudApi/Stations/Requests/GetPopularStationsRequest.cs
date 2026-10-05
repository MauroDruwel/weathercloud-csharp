using global::System.Text.Json.Serialization;
using WeathercloudApi.Core;

namespace WeathercloudApi;

[Serializable]
public record GetPopularStationsRequest
{
    [JsonIgnore]
    public required string Country { get; set; }

    [JsonIgnore]
    public required GetPopularStationsRequestPeriod Period { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
