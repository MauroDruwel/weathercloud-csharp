using global::System.Text.Json.Serialization;
using Weathercloud.Core;

namespace Weathercloud;

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
