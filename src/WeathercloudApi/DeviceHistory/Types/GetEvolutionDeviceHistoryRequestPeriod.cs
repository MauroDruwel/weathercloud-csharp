using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using WeathercloudApi.Core;

namespace WeathercloudApi;

[JsonConverter(
    typeof(GetEvolutionDeviceHistoryRequestPeriod.GetEvolutionDeviceHistoryRequestPeriodSerializer)
)]
[Serializable]
public readonly record struct GetEvolutionDeviceHistoryRequestPeriod : IStringEnum
{
    public static readonly GetEvolutionDeviceHistoryRequestPeriod Day = new(Values.Day);

    public static readonly GetEvolutionDeviceHistoryRequestPeriod Week = new(Values.Week);

    public static readonly GetEvolutionDeviceHistoryRequestPeriod Month = new(Values.Month);

    public static readonly GetEvolutionDeviceHistoryRequestPeriod Year = new(Values.Year);

    public GetEvolutionDeviceHistoryRequestPeriod(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static GetEvolutionDeviceHistoryRequestPeriod FromCustom(string value)
    {
        return new GetEvolutionDeviceHistoryRequestPeriod(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(GetEvolutionDeviceHistoryRequestPeriod value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetEvolutionDeviceHistoryRequestPeriod value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetEvolutionDeviceHistoryRequestPeriod value) =>
        value.Value;

    public static explicit operator GetEvolutionDeviceHistoryRequestPeriod(string value) =>
        new(value);

    internal class GetEvolutionDeviceHistoryRequestPeriodSerializer
        : JsonConverter<GetEvolutionDeviceHistoryRequestPeriod>
    {
        public override GetEvolutionDeviceHistoryRequestPeriod Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new GetEvolutionDeviceHistoryRequestPeriod(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetEvolutionDeviceHistoryRequestPeriod value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetEvolutionDeviceHistoryRequestPeriod ReadAsPropertyName(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new GetEvolutionDeviceHistoryRequestPeriod(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetEvolutionDeviceHistoryRequestPeriod value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Day = "day";

        public const string Week = "week";

        public const string Month = "month";

        public const string Year = "year";
    }
}
