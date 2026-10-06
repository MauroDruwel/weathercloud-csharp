using global::System.Net.Http;

namespace Weathercloud.Core;

internal static class HttpMethodExtensions
{
    public static readonly HttpMethod Patch = new("PATCH");
}
