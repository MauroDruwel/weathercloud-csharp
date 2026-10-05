using NUnit.Framework;
using WeathercloudApi;
using WeathercloudApi.Test.Unit.MockServer;
using WeathercloudApi.Test.Utils;

namespace WeathercloudApi.Test.Unit.MockServer.DeviceLive;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetValuesTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "epoch": 1,
              "temp": 1.1,
              "dew": 1.1,
              "chill": 1.1,
              "heat": 1.1,
              "hum": 1,
              "bar": 1.1,
              "wdir": 1,
              "wdiravg": 1,
              "wspd": 1.1,
              "wspdavg": 1.1,
              "wspdhi": 1.1,
              "rainrate": 1.1,
              "rain": 1.1,
              "solarrad": 1.1,
              "uvi": 1.1,
              "tempin": 1.1,
              "humin": 1,
              "heatin": 1.1
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/device/values/deviceId")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.DeviceLive.GetValuesAsync(
            new GetValuesDeviceLiveRequest { DeviceId = "deviceId" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "epoch": 1779825116,
              "temp": 24.8,
              "dew": 15.2,
              "chill": 24.8,
              "heat": 24.8,
              "hum": 55,
              "bar": 1024.9,
              "wdir": 344,
              "wdiravg": 344,
              "wspd": 0.6,
              "wspdavg": 0.6,
              "wspdhi": 1,
              "rainrate": 0,
              "rain": 0,
              "solarrad": 0,
              "uvi": 0,
              "tempin": 1.1,
              "humin": 1,
              "heatin": 1.1
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/device/values/5726468552")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.DeviceLive.GetValuesAsync(
            new GetValuesDeviceLiveRequest { DeviceId = "5726468552" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
