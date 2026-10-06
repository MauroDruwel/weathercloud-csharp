using global::System.Text.Json.Serialization;
using Weathercloud.Core;

namespace Weathercloud;

[Serializable]
public record GetUpdateStatusDeviceLiveRequest
{
    /// <summary>
    /// Device ID
    /// </summary>
    [JsonPropertyName("d")]
    public required string D { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
