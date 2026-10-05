namespace WeathercloudApi;

public partial interface IForecastClient
{
    WithRawResponseTask<ForecastResponse> GetDailyAsync(
        GetDailyForecastRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
