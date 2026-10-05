using global::System.Net.Http;

namespace WeathercloudApi.Core;

internal static class HttpMethodExtensions
{
    public static readonly HttpMethod Patch = new("PATCH");
}
