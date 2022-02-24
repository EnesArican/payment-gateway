namespace Payment.Gateway.Api.Client.Clients;

using System.Net.Http.Json;
using Payment.Gateway.Api.Client.Dtos;
using Payment.Gateway.Api.Client.Interfaces;

public class PaymentClient : IPaymentClient
{
    private readonly HttpClient _httpClient;

    private readonly string PaymentsUri = "payments";

    public PaymentClient(HttpClient httpClient) =>
        _httpClient = httpClient;

    public async Task<SendPaymentResponse> SendPaymentAsync(SendPaymentRequest request, CancellationToken token)
    {
        var response = await _httpClient.PostAsJsonAsync(PaymentsUri, request, token);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<SendPaymentResponse>(cancellationToken: token)
            ?? throw new InvalidOperationException("Unable to deserialize response content.");
    }

    public async Task<GetPaymentResponse> GetPaymentInfoAsync(int paymentId, CancellationToken token)
    {
        return await _httpClient.GetFromJsonAsync<GetPaymentResponse>($"{PaymentsUri}/{paymentId}", token)
            ?? throw new InvalidOperationException("Unable to deserialize response content.");
    }
}
