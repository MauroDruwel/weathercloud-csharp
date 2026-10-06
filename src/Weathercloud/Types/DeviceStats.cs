using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Weathercloud.Core;

namespace Weathercloud;

/// <summary>
/// Current readings and period statistics for all sensors.
/// All values are `[unix_timestamp, value]` tuples (`TimestampValue`).
///
/// **Key pattern:** `{sensor}_{period}_{type}`
/// - Sensors: `temp`, `tempin`, `dew`, `chill`, `heat`, `heatin`, `hum`, `humin`, `bar`, `wdir`, `wdiravg`, `wspd`, `wspdavg`, `wspdhi`, `rainrate`, `rain`, `solarrad`, `uvi`
/// - Period types: `current`, `day_max`, `day_min`, `month_max`, `month_min`, `year_max`, `year_min`
/// - Rain also has: `day_total`, `month_total`, `year_total`
/// - Solarrad also has: `day_hours`, `month_hours`, `year_hours`
/// </summary>
[Serializable]
public record DeviceStats : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unix timestamp of last reading
    /// </summary>
    [JsonPropertyName("last_update")]
    public int? LastUpdate { get; set; }

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
