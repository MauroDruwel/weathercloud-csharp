using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Weathercloud.Core;

namespace Weathercloud;

[JsonConverter(
    typeof(LoginAuthRequestLoginFormRememberMe.LoginAuthRequestLoginFormRememberMeSerializer)
)]
[Serializable]
public readonly record struct LoginAuthRequestLoginFormRememberMe : IStringEnum
{
    public static readonly LoginAuthRequestLoginFormRememberMe Zero = new(Values.Zero);

    public static readonly LoginAuthRequestLoginFormRememberMe One = new(Values.One);

    public LoginAuthRequestLoginFormRememberMe(string value)
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
    public static LoginAuthRequestLoginFormRememberMe FromCustom(string value)
    {
        return new LoginAuthRequestLoginFormRememberMe(value);
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

    public static bool operator ==(LoginAuthRequestLoginFormRememberMe value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(LoginAuthRequestLoginFormRememberMe value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(LoginAuthRequestLoginFormRememberMe value) =>
        value.Value;

    public static explicit operator LoginAuthRequestLoginFormRememberMe(string value) => new(value);

    internal class LoginAuthRequestLoginFormRememberMeSerializer
        : JsonConverter<LoginAuthRequestLoginFormRememberMe>
    {
        public override LoginAuthRequestLoginFormRememberMe Read(
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
            return new LoginAuthRequestLoginFormRememberMe(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            LoginAuthRequestLoginFormRememberMe value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override LoginAuthRequestLoginFormRememberMe ReadAsPropertyName(
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
            return new LoginAuthRequestLoginFormRememberMe(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            LoginAuthRequestLoginFormRememberMe value,
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
        public const string Zero = "0";

        public const string One = "1";
    }
}
