using global::System.Text.Json.Serialization;
using WeathercloudApi.Core;

namespace WeathercloudApi;

[Serializable]
public record GetNearbyStationsRequest
{
    [JsonIgnore]
    public required double Lat { get; set; }

    [JsonIgnore]
    public required double Lon { get; set; }

    [JsonIgnore]
    public required int Km { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
