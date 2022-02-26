namespace Payment.Gateway.Api.Components.Interfaces;

using Payment.Gateway.Api.Components.Dtos;
using Payment.Gateway.Api.Components.Models;

public interface IPaymentService
{
    Task<SendPaymentResponse> SendPaymentRequestAsync(PaymentRequest request, CancellationToken token);

    Task<PaymentDetails> GetPaymentAsync(int paymentId, CancellationToken token);

    Task<IList<PaymentDetails>> GetAllPaymentsAsync(CancellationToken token);
}
