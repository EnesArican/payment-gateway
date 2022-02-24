namespace Payment.Gateway.Api.Interfaces;

using Payment.Gateway.Api.Dtos;
using Payment.Gateway.Api.Models;

public interface IPaymentService
{
    Task<SendPaymentResponse> SendPaymentRequestAsync(PaymentRequest request, CancellationToken token);

    Task<PaymentDetails> GetPaymentAsync(int paymentId, CancellationToken token);
}
