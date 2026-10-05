namespace WeathercloudApi;

/// <summary>
/// Base exception class for all exceptions thrown by the SDK.
/// </summary>
public class WeathercloudApiException(string message, Exception? innerException = null)
    : Exception(message, innerException);
