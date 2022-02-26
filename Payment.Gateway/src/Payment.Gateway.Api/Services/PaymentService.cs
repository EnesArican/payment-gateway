namespace Payment.Gateway.Api.Services;

using AutoMapper;
using client = Client.Dtos;
using Payment.Gateway.Api.Components.Dtos;
using Payment.Gateway.Api.Client.Interfaces;
using Payment.Gateway.Api.Components.Models;
using Payment.Gateway.Api.Components.Interfaces;

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

    public async Task<IList<PaymentDetails>> GetAllPaymentsAsync(CancellationToken token) 
    {
        var response = await _paymentClient.GetAllPaymentsInfoAsync(token);

        return response.Select(_mapper.Map<PaymentDetails>).ToList();
    }
}

