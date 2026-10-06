using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Weathercloud.Core;

namespace Weathercloud;

[Serializable]
public record DeviceInfoDevice : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Account type (0 = free)
    /// </summary>
    [JsonPropertyName("account")]
    public int? Account { get; set; }

    /// <summary>
    /// "1" = online, "2" = recently online, "3" = offline
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>
    /// City name
    /// </summary>
    [JsonPropertyName("city")]
    public string? City { get; set; }

    /// <summary>
    /// Altitude in metres (as string)
    /// </summary>
    [JsonPropertyName("altitude")]
    public string? Altitude { get; set; }

    /// <summary>
    /// URL to station photo, or null
    /// </summary>
    [JsonPropertyName("image")]
    public string? Image { get; set; }

    [JsonPropertyName("isWebcam")]
    public bool? IsWebcam { get; set; }

    [JsonPropertyName("favorite")]
    public bool? Favorite { get; set; }

    [JsonPropertyName("social")]
    public bool? Social { get; set; }

    /// <summary>
    /// Seconds since last update
    /// </summary>
    [JsonPropertyName("update")]
    public int? Update { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
