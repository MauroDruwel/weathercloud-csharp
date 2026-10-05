using global::System.Text.Json.Serialization;
using WeathercloudApi.Core;

namespace WeathercloudApi;

[Serializable]
public record GetDevicesMapRequest
{
    /// <summary>
    /// Filter by user (empty = all)
    /// </summary>
    [JsonPropertyName("user")]
    public string? User { get; set; }

    /// <summary>
    /// lat,lon,zoom format
    /// </summary>
    [JsonPropertyName("location")]
    public string? Location { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
