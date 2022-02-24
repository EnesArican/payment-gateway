namespace Payment.Gateway.Api.Services;

using AutoMapper;
using client = Client.Dtos;
using Payment.Gateway.Api.Dtos;
using Payment.Gateway.Api.Models;
using Payment.Gateway.Api.Interfaces;
using Payment.Gateway.Api.Client.Interfaces;

public class PaymentService : IPaymentService
{
    private readonly IMapper _mapper;
    private readonly IPaymentClient _paymentClient;
    public PaymentService(IMapper mapper, 
                          IPaymentClient paymentClient)
    {
        _mapper = mapper;
        _paymentClient = paymentClient;
    }

    public async Task<SendPaymentResponse> SendPaymentRequestAsync(PaymentRequest request, CancellationToken token)
    {
        var clientRequest = _mapper.Map<client.SendPaymentRequest>(request);

        var response = await _paymentClient.SendPaymentAsync(clientRequest, token);

        return new SendPaymentResponse { PaymentId = response.Id };
    }

    public async Task<PaymentDetails> GetPaymentAsync(int paymentId, CancellationToken token)
    {
        var response = await _paymentClient.GetPaymentInfoAsync(paymentId, token);

        return _mapper.Map<PaymentDetails>(response);
    }
}

