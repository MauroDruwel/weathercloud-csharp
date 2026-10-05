using NUnit.Framework;
using WeathercloudApi;
using WeathercloudApi.Test.Unit.MockServer;

namespace WeathercloudApi.Test.Unit.MockServer.Auth;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class LoginTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest_1()
    {
        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/signin")
                    .WithHeader("Content-Type", "application/x-www-form-urlencoded")
                    .UsingPost()
                    .WithBody(
                        new WireMock.Matchers.FormUrlEncodedMatcher([
                            "LoginForm[entity]=LoginForm[entity]",
                            "LoginForm[password]=LoginForm[password]",
                        ])
                    )
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.Auth.LoginAsync(
                new LoginAuthRequest
                {
                    LoginFormEntity = "LoginForm[entity]",
                    LoginFormPassword = "LoginForm[password]",
                    LoginFormRememberMe = null,
                }
            )
        );
    }

    [NUnit.Framework.Test]
    public void MockServerTest_2()
    {
        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/signin")
                    .WithHeader("Content-Type", "application/x-www-form-urlencoded")
                    .UsingPost()
                    .WithBody(
                        new WireMock.Matchers.FormUrlEncodedMatcher([
                            "LoginForm[entity]=LoginForm[entity]",
                            "LoginForm[password]=LoginForm[password]",
                        ])
                    )
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.Auth.LoginAsync(
                new LoginAuthRequest
                {
                    LoginFormEntity = "LoginForm[entity]",
                    LoginFormPassword = "LoginForm[password]",
                }
            )
        );
    }
}
