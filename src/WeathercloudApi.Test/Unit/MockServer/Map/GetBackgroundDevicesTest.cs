using NUnit.Framework;
using WeathercloudApi;
using WeathercloudApi.Test.Unit.MockServer;
using WeathercloudApi.Test.Utils;

namespace WeathercloudApi.Test.Unit.MockServer.Map;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetBackgroundDevicesTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "devices": [
                [
                  {
                    "key": "value"
                  },
                  {
                    "key": "value"
                  }
                ],
                [
                  {
                    "key": "value"
                  },
                  {
                    "key": "value"
                  }
                ]
              ],
              "owner": [
                [
                  {
                    "key": "value"
                  },
                  {
                    "key": "value"
                  }
                ],
                [
                  {
                    "key": "value"
                  },
                  {
                    "key": "value"
                  }
                ]
              ],
              "favorites": [
                [
                  {
                    "key": "value"
                  },
                  {
                    "key": "value"
                  }
                ],
                [
                  {
                    "key": "value"
                  },
                  {
                    "key": "value"
                  }
                ]
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/map/bgdevices")
                    .WithHeader("Content-Type", "application/x-www-form-urlencoded")
                    .UsingPost()
                    .WithBody(new WireMock.Matchers.FormUrlEncodedMatcher([]))
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Map.GetBackgroundDevicesAsync(
            new GetBackgroundDevicesMapRequest { User = null }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "devices": [
                [
                  "RWACTX",
                  "Wilsele-Herent",
                  50.904295,
                  4.69565,
                  2,
                  0,
                  277,
                  54,
                  10270,
                  19,
                  336,
                  0,
                  0,
                  8050,
                  47
                ]
              ],
              "owner": [
                [
                  {
                    "key": "value"
                  }
                ]
              ],
              "favorites": [
                [
                  {
                    "key": "value"
                  }
                ]
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/map/bgdevices")
                    .WithHeader("Content-Type", "application/x-www-form-urlencoded")
                    .UsingPost()
                    .WithBody(new WireMock.Matchers.FormUrlEncodedMatcher([]))
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Map.GetBackgroundDevicesAsync(
            new GetBackgroundDevicesMapRequest()
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
