namespace Payment.Gateway.Api.Client.Dtos;

public record GetPaymentResponse
{
    public int Id { get; init; }
    public string CardNumber { get; init; } = default!;
    public decimal Amount { get; init; }
    public int Cvv { get; init; }
    public string Currency { get; init; } = default!;
    public string? Description { get; init; }
    public string ExpiryDate { get; init; } = default!;
    public string Status { get; init; } = default!;
}