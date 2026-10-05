using NUnit.Framework;
using WeathercloudApi;
using WeathercloudApi.Test.Unit.MockServer;
using WeathercloudApi.Test.Utils;

namespace WeathercloudApi.Test.Unit.MockServer.DeviceLive;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetOwnerProfileTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "observer": {
                "name": "name",
                "nickname": "nickname",
                "company": "company"
              },
              "followers": {
                "number": "number"
              },
              "device": {
                "brand": "brand",
                "model": "model"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/device/ajaxprofile")
                    .WithHeader("Content-Type", "application/x-www-form-urlencoded")
                    .UsingPost()
                    .WithBody(new WireMock.Matchers.FormUrlEncodedMatcher(["d=d"]))
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.DeviceLive.GetOwnerProfileAsync(
            new GetOwnerProfileDeviceLiveRequest { D = "d" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "observer": {
                "name": "Gino Wallaert",
                "nickname": "Ginometeo",
                "company": ""
              },
              "followers": {
                "number": "1"
              },
              "device": {
                "brand": "Other",
                "model": "Other"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/device/ajaxprofile")
                    .WithHeader("Content-Type", "application/x-www-form-urlencoded")
                    .UsingPost()
                    .WithBody(new WireMock.Matchers.FormUrlEncodedMatcher(["d=5726468552"]))
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.DeviceLive.GetOwnerProfileAsync(
            new GetOwnerProfileDeviceLiveRequest { D = "5726468552" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
