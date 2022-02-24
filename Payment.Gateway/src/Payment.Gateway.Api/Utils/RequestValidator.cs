namespace Payment.Gateway.Api.Utils;

using Payment.Gateway.Api.Client.Utils;
using System.Globalization;
public static class RequestValidator
{
    public static void ValidateExpiryDate(string expiryDate) 
    {

        if (!DateTime.TryParseExact(expiryDate, "MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
        {
            throw new AppException("Expiry date is in invalid format, Please provide a date in MM/yyyy format.");
        }

        if (date.Year < DateTime.Now.Year || (date.Year == DateTime.Now.Year && date.Month < DateTime.Now.Month)) 
        {
            throw new AppException("Card expiration date has passed.");
        }
    }

    public static void ValidatePaymentAmount(decimal amount) 
    {
        if (amount <= 0)
            throw new AppException("Invalid payment amount. Please provide a value greater than 0.");
    }
}
