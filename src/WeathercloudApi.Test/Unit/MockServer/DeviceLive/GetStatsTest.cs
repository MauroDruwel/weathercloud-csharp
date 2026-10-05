using NUnit.Framework;
using WeathercloudApi;
using WeathercloudApi.Test.Unit.MockServer;
using WeathercloudApi.Test.Utils;

namespace WeathercloudApi.Test.Unit.MockServer.DeviceLive;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetStatsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "last_update": 1
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/device/stats")
                    .WithParam("code", "code")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.DeviceLive.GetStatsAsync(
            new GetStatsDeviceLiveRequest { Code = "code" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "last_update": 1
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/device/stats")
                    .WithParam("code", "5726468552")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.DeviceLive.GetStatsAsync(
            new GetStatsDeviceLiveRequest { Code = "5726468552" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
