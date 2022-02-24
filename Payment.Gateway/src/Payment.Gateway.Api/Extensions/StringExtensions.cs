using System.Text.RegularExpressions;

namespace Payment.Gateway.Api.Extensions;

public static class StringExtensions
{
    public static string Mask(this string text) 
    {
        if (text.Length < 12)
            throw new InvalidOperationException("cannot mask string of length less than 12.");

        var firstDigits = text.Substring(0, 6);
        var lastDigits = text.Substring(text.Length - 4, 4);

        var requiredMask = new String('X', text.Length - firstDigits.Length - lastDigits.Length);

        var maskedString = string.Concat(firstDigits, requiredMask, lastDigits);
        return Regex.Replace(maskedString, ".{4}", "$0 ");
    }
}
