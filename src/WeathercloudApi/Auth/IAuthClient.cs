namespace WeathercloudApi;

public partial interface IAuthClient
{
    /// <summary>
    /// Authenticates a user session to allow viewing private indoor sensors (`tempin`, `humin`, `heatin`) for the user's station.
    /// This endpoint expects form urlencoded data and returns a `302 Found` redirect on successful login.
    /// </summary>
    WithRawResponseTask LoginAsync(
        LoginAuthRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
