namespace Payment.Gateway.Api.Client.Utils;

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
