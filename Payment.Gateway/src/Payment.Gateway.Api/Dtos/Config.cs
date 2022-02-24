namespace Payment.Gateway.Api.Dtos;

public record Config
{
    public string CkoBankUrl { get; init; } = default!;
}

