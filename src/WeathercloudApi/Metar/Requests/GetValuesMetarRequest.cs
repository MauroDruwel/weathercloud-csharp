using global::System.Text.Json.Serialization;
using WeathercloudApi.Core;

namespace WeathercloudApi;

[Serializable]
public record GetValuesMetarRequest
{
    /// <summary>
    /// ICAO airport code
    /// </summary>
    [JsonIgnore]
    public required string DeviceId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
