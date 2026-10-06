using NUnit.Framework;
using Weathercloud;
using Weathercloud.Test.Unit.MockServer;
using Weathercloud.Test.Utils;

namespace Weathercloud.Test.Unit.MockServer.DeviceLive;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetWindRoseTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "date": 1,
              "values": [
                {
                  "sum": 1.1,
                  "scale": [
                    1,
                    1
                  ]
                },
                {
                  "sum": 1.1,
                  "scale": [
                    1,
                    1
                  ]
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/device/wind")
                    .WithParam("code", "code")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.DeviceLive.GetWindRoseAsync(
            new GetWindRoseDeviceLiveRequest { Code = "code" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "date": 1,
              "values": [
                {
                  "sum": 1.1,
                  "scale": [
                    1
                  ]
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/device/wind")
                    .WithParam("code", "5726468552")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.DeviceLive.GetWindRoseAsync(
            new GetWindRoseDeviceLiveRequest { Code = "5726468552" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
