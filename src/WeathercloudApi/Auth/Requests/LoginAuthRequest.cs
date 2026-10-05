using global::System.Text.Json.Serialization;
using WeathercloudApi.Core;

namespace WeathercloudApi;

[Serializable]
public record LoginAuthRequest
{
    /// <summary>
    /// Username or email address
    /// </summary>
    [JsonPropertyName("LoginForm[entity]")]
    public required string LoginFormEntity { get; set; }

    /// <summary>
    /// Account password
    /// </summary>
    [JsonPropertyName("LoginForm[password]")]
    public required string LoginFormPassword { get; set; }

    /// <summary>
    /// Keep the user logged in
    /// </summary>
    [JsonPropertyName("LoginForm[rememberMe]")]
    public LoginAuthRequestLoginFormRememberMe? LoginFormRememberMe { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
