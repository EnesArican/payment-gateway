namespace Payment.Gateway.Api.Components.Utils;

public class AppException : Exception
{
    public AppException()
    {
    }

    public AppException(string message)
        : base(message)
    {
    }
}
