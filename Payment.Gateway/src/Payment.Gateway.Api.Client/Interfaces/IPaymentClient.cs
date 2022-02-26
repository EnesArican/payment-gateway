namespace Payment.Gateway.Api.Client.Interfaces;

using Payment.Gateway.Api.Client.Dtos;

public interface IPaymentClient
{
    Task<SendPaymentResponse> SendPaymentAsync(SendPaymentRequest request, CancellationToken token);

    Task<GetPaymentResponse> GetPaymentInfoAsync(int paymentId, CancellationToken token);

    Task<IList<GetPaymentResponse>> GetAllPaymentsInfoAsync(CancellationToken token);
}

