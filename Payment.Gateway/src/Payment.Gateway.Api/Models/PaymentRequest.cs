namespace Payment.Gateway.Api.Models;

using Payment.Gateway.Api.Utils;
using System.ComponentModel.DataAnnotations;

public record PaymentRequest
{
    private decimal _amount;
    private string _expiryDate = default!;

    [Required/*, CreditCard*/]
    public string CardNumber { get; init; } = default!;
    [Required]
    public int Cvv { get; init; }
    [Required]
    public string Currency { get; init; } = default!;

    public string? Description { get; init; }

    [Required]
    public decimal Amount 
    { 
        get => _amount;
        init 
        {
            RequestValidator.ValidatePaymentAmount(value);
            _amount = value;
        } 
    }

    [Required]
    public string ExpiryDate
    {
        get => _expiryDate;
        init 
        {
            RequestValidator.ValidateExpiryDate(value);
            _expiryDate = value;
        }
     }

}