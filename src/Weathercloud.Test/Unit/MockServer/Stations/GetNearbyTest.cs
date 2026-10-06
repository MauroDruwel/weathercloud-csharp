using NUnit.Framework;
using Weathercloud;
using Weathercloud.Test.Unit.MockServer;
using Weathercloud.Test.Utils;

namespace Weathercloud.Test.Unit.MockServer.Stations;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetNearbyTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "devices": [
                {
                  "type": "type",
                  "code": "code",
                  "name": "name",
                  "city": "city",
                  "latitude": "latitude",
                  "longitude": "longitude",
                  "elevation": "elevation",
                  "image": "image",
                  "isWebcam": true,
                  "account": 1,
                  "isFavorite": true,
                  "update": 1,
                  "data": "data",
                  "values": {
                    "epoch": "epoch",
                    "temp": "temp",
                    "hum": "hum",
                    "dew": "dew",
                    "chill": "chill",
                    "heat": "heat",
                    "bar": "bar",
                    "wdir": "wdir",
                    "wspd": "wspd",
                    "wspdavg": "wspdavg",
                    "wspdhi": "wspdhi",
                    "rainrate": "rainrate",
                    "rain": "rain",
                    "solarrad": "solarrad",
                    "uvi": "uvi",
                    "tempin": "tempin",
                    "humin": "humin"
                  }
                },
                {
                  "type": "type",
                  "code": "code",
                  "name": "name",
                  "city": "city",
                  "latitude": "latitude",
                  "longitude": "longitude",
                  "elevation": "elevation",
                  "image": "image",
                  "isWebcam": true,
                  "account": 1,
                  "isFavorite": true,
                  "update": 1,
                  "data": "data",
                  "values": {
                    "epoch": "epoch",
                    "temp": "temp",
                    "hum": "hum",
                    "dew": "dew",
                    "chill": "chill",
                    "heat": "heat",
                    "bar": "bar",
                    "wdir": "wdir",
                    "wspd": "wspd",
                    "wspdavg": "wspdavg",
                    "wspdhi": "wspdhi",
                    "rainrate": "rainrate",
                    "rain": "rain",
                    "solarrad": "solarrad",
                    "uvi": "uvi",
                    "tempin": "tempin",
                    "humin": "humin"
                  }
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/page/coordinates/latitude/1.1/longitude/1.1/distance/1")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Stations.GetNearbyAsync(
            new GetNearbyStationsRequest
            {
                Lat = 1.1,
                Lon = 1.1,
                Km = 1,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "devices": [
                {
                  "type": "device",
                  "code": "2034767194",
                  "name": "WeatherStation Skyline",
                  "city": "city",
                  "latitude": "latitude",
                  "longitude": "longitude",
                  "elevation": "elevation",
                  "image": "image",
                  "isWebcam": true,
                  "account": 1,
                  "isFavorite": true,
                  "update": 1,
                  "data": "data"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/page/coordinates/latitude/1.1/longitude/1.1/distance/1")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Stations.GetNearbyAsync(
            new GetNearbyStationsRequest
            {
                Lat = 1.1,
                Lon = 1.1,
                Km = 1,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
