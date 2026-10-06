using NUnit.Framework;
using Weathercloud;
using Weathercloud.Test.Unit.MockServer;
using Weathercloud.Test.Utils;

namespace Weathercloud.Test.Unit.MockServer.DeviceLive;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetInfoTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "device": {
                "account": 1,
                "status": "status",
                "city": "city",
                "altitude": "altitude",
                "image": "image",
                "isWebcam": true,
                "favorite": true,
                "social": true,
                "update": 1
              },
              "values": {
                "temp": "temp",
                "hum": "hum",
                "dew": "dew",
                "wspdavg": "wspdavg",
                "wdiravg": "wdiravg",
                "bar": "bar",
                "rain": "rain",
                "rainrate": "rainrate",
                "solarrad": "solarrad",
                "uvi": "uvi"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/device/info/deviceId")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.DeviceLive.GetInfoAsync(
            new GetInfoDeviceLiveRequest { DeviceId = "deviceId" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "device": {
                "account": 1,
                "status": "status",
                "city": "city",
                "altitude": "altitude",
                "image": "image",
                "isWebcam": true,
                "favorite": true,
                "social": true,
                "update": 1
              },
              "values": {
                "temp": "temp",
                "hum": "hum",
                "dew": "dew",
                "wspdavg": "wspdavg",
                "wdiravg": "wdiravg",
                "bar": "bar",
                "rain": "rain",
                "rainrate": "rainrate",
                "solarrad": "solarrad",
                "uvi": "uvi"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/device/info/5726468552")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.DeviceLive.GetInfoAsync(
            new GetInfoDeviceLiveRequest { DeviceId = "5726468552" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
