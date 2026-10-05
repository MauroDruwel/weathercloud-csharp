using NUnit.Framework;
using WeathercloudApi;
using WeathercloudApi.Test.Unit.MockServer;
using WeathercloudApi.Test.Utils;

namespace WeathercloudApi.Test.Unit.MockServer.DeviceHistory;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetEvolutionTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "status": "status",
              "data": {
                "timezone": "timezone",
                "summary": {
                  "summary": {
                    "samples": 1,
                    "sum": 1.1,
                    "min": 1.1,
                    "min_time": 1,
                    "max": 1.1,
                    "max_time": 1
                  }
                },
                "values": {
                  "values": {
                    "values": {
                      "samples": 1,
                      "stats": {
                        "sum": 1.1,
                        "min": 1.1,
                        "min_time": 1,
                        "max": 1.1,
                        "max_time": 1
                      }
                    }
                  }
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/device/evolution")
                    .WithHeader("Content-Type", "application/x-www-form-urlencoded")
                    .UsingPost()
                    .WithBody(
                        new WireMock.Matchers.FormUrlEncodedMatcher([
                            "device=device",
                            "variable=1",
                            "period=day",
                        ])
                    )
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.DeviceHistory.GetEvolutionAsync(
            new GetEvolutionDeviceHistoryRequest
            {
                Device = "device",
                Variable = 1,
                Period = GetEvolutionDeviceHistoryRequestPeriod.Day,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "status": "success",
              "data": {
                "timezone": "Europe/Brussels",
                "summary": {
                  "key": {}
                },
                "values": {
                  "key": {
                    "key": {}
                  }
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/device/evolution")
                    .WithHeader("Content-Type", "application/x-www-form-urlencoded")
                    .UsingPost()
                    .WithBody(
                        new WireMock.Matchers.FormUrlEncodedMatcher([
                            "device=5726468552",
                            "variable=101",
                            "period=day",
                        ])
                    )
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.DeviceHistory.GetEvolutionAsync(
            new GetEvolutionDeviceHistoryRequest
            {
                Device = "5726468552",
                Variable = 101,
                Period = GetEvolutionDeviceHistoryRequestPeriod.Day,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
