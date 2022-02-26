namespace Payment.Gateway.Api.Components.Dtos;

public record Config
{
    public string CkoBankUrl { get; init; } = default!;
}

