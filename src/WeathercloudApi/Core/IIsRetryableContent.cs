namespace WeathercloudApi.Core;

public interface IIsRetryableContent
{
    public bool IsRetryable { get; }
}
