using NUnit.Framework;
using Weathercloud.Test.Unit.MockServer;
using Weathercloud.Test.Utils;

namespace Weathercloud.Test.Unit.MockServer.Map;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetMetarsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "metars": [
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
                    .WithPath("/map/metars")
                    .WithHeader("Content-Type", "application/x-www-form-urlencoded")
                    .UsingPost()
                    .WithBody(
                        new WireMock.Matchers.FormUrlEncodedMatcher(["string=[object Object]"])
                    )
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Map.GetMetarsAsync(
            new Dictionary<string, object?>()
            {
                {
                    "string",
                    new Dictionary<object, object?>() { { "key", "value" } }
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "metars": [
                [
                  "EBBR",
                  "Brussels",
                  50.9014,
                  4.4844,
                  2,
                  0,
                  260,
                  58,
                  10220,
                  80,
                  260,
                  0,
                  "",
                  "",
                  ""
                ]
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/map/metars")
                    .WithHeader("Content-Type", "application/x-www-form-urlencoded")
                    .UsingPost()
                    .WithBody(new WireMock.Matchers.FormUrlEncodedMatcher(["key=value"]))
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Map.GetMetarsAsync(
            new Dictionary<string, object?>() { { "key", "value" } }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
