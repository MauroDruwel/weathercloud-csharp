using NUnit.Framework;
using WeathercloudApi;
using WeathercloudApi.Test.Unit.MockServer;

namespace WeathercloudApi.Test.Unit.MockServer.Stations;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetStationPageTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = "string";

        Server
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/ddeviceId").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Stations.GetStationPageAsync(
            new GetStationPageStationsRequest { DeviceId = "deviceId" }
        );
        Assert.That(response, Is.EqualTo(mockResponse));
    }

    [NUnit.Framework.Test]
    public void MockServerTest_2()
    {
        Server
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/ddeviceId").UsingGet())
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.Stations.GetStationPageAsync(
                new GetStationPageStationsRequest { DeviceId = "deviceId" }
            )
        );
    }
}
