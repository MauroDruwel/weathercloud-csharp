using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using WeathercloudApi.Core;

namespace WeathercloudApi;

[Serializable]
public record ForecastResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("info")]
    public ForecastResponseInfo? Info { get; set; }

    [JsonPropertyName("location")]
    public ForecastResponseLocation? Location { get; set; }

    /// <summary>
    /// Keyed by date string (YYYY-MM-DD)
    /// </summary>
    [JsonPropertyName("forecast")]
    public Dictionary<string, ForecastResponseForecastValue>? Forecast { get; set; }

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
