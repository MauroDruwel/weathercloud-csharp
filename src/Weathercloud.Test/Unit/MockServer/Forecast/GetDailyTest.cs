using NUnit.Framework;
using Weathercloud;
using Weathercloud.Test.Unit.MockServer;
using Weathercloud.Test.Utils;

namespace Weathercloud.Test.Unit.MockServer.Forecast;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetDailyTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "info": {
                "source": "source",
                "web": "web",
                "days": 1
              },
              "location": {
                "name": "name"
              },
              "forecast": {
                "forecast": {
                  "weather": {
                    "code": 1
                  },
                  "temperature": {
                    "max": 1,
                    "min": 1
                  }
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/forecast/daily")
                    .WithParam("id", "id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Forecast.GetDailyAsync(
            new GetDailyForecastRequest { Id = "id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "info": {
                "source": "WMO",
                "web": "https://worldweather.wmo.int",
                "days": 6
              },
              "location": {
                "name": "Ingelmunster"
              },
              "forecast": {
                "2026-05-28": {
                  "weather": {
                    "code": 12
                  },
                  "temperature": {
                    "max": 29,
                    "min": 16
                  }
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/forecast/daily")
                    .WithParam("id", "5726468552")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Forecast.GetDailyAsync(
            new GetDailyForecastRequest { Id = "5726468552" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
