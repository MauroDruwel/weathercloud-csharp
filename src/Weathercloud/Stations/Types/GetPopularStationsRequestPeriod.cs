using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Weathercloud.Core;

namespace Weathercloud;

[JsonConverter(typeof(GetPopularStationsRequestPeriod.GetPopularStationsRequestPeriodSerializer))]
[Serializable]
public readonly record struct GetPopularStationsRequestPeriod : IStringEnum
{
    public static readonly GetPopularStationsRequestPeriod Day = new(Values.Day);

    public static readonly GetPopularStationsRequestPeriod Week = new(Values.Week);

    public static readonly GetPopularStationsRequestPeriod Month = new(Values.Month);

    public GetPopularStationsRequestPeriod(string value)
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
    public static GetPopularStationsRequestPeriod FromCustom(string value)
    {
        return new GetPopularStationsRequestPeriod(value);
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

    public static bool operator ==(GetPopularStationsRequestPeriod value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetPopularStationsRequestPeriod value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetPopularStationsRequestPeriod value) => value.Value;

    public static explicit operator GetPopularStationsRequestPeriod(string value) => new(value);

    internal class GetPopularStationsRequestPeriodSerializer
        : JsonConverter<GetPopularStationsRequestPeriod>
    {
        public override GetPopularStationsRequestPeriod Read(
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
            return new GetPopularStationsRequestPeriod(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetPopularStationsRequestPeriod value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetPopularStationsRequestPeriod ReadAsPropertyName(
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
            return new GetPopularStationsRequestPeriod(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetPopularStationsRequestPeriod value,
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
    }
}
