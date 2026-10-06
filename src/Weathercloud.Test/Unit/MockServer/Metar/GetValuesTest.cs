using NUnit.Framework;
using Weathercloud;
using Weathercloud.Test.Unit.MockServer;
using Weathercloud.Test.Utils;

namespace Weathercloud.Test.Unit.MockServer.Metar;

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
                    .WithPath("/metar/values/deviceId")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Metar.GetValuesAsync(
            new GetValuesMetarRequest { DeviceId = "deviceId" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
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
                WireMock.RequestBuilders.Request.Create().WithPath("/metar/values/EBBR").UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Metar.GetValuesAsync(
            new GetValuesMetarRequest { DeviceId = "EBBR" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
