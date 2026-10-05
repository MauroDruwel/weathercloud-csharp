using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using WeathercloudApi.Core;

namespace WeathercloudApi;

/// <summary>
/// Station entry returned by page/coordinates
/// </summary>
[Serializable]
public record PageDevice : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// Device ID (numeric string)
    /// </summary>
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    /// <summary>
    /// Station name as set by the owner
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("city")]
    public string? City { get; set; }

    [JsonPropertyName("latitude")]
    public string? Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public string? Longitude { get; set; }

    /// <summary>
    /// Altitude in metres
    /// </summary>
    [JsonPropertyName("elevation")]
    public string? Elevation { get; set; }

    [JsonPropertyName("image")]
    public string? Image { get; set; }

    [JsonPropertyName("isWebcam")]
    public bool? IsWebcam { get; set; }

    [JsonPropertyName("account")]
    public int? Account { get; set; }

    [JsonPropertyName("isFavorite")]
    public bool? IsFavorite { get; set; }

    /// <summary>
    /// Seconds since last update
    /// </summary>
    [JsonPropertyName("update")]
    public int? Update { get; set; }

    /// <summary>
    /// Distance from query point (km)
    /// </summary>
    [JsonPropertyName("data")]
    public string? Data { get; set; }

    /// <summary>
    /// Scaled integer sensor readings — divide by 10 for most values.
    /// e.g. `temp: 281` → 28.1°C, `bar: 10247` → 1024.7 hPa, `uvi: 70` → UV 7.0
    /// </summary>
    [JsonPropertyName("values")]
    public PageDeviceValues? Values { get; set; }

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
