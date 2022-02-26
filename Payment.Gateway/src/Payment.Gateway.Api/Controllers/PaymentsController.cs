namespace Payment.Gateway.Api.Controllers;

using Microsoft.AspNetCore.Mvc;
using Payment.Gateway.Api.Components.Utils;
using Payment.Gateway.Api.Components.Models;
using Payment.Gateway.Api.Components.Interfaces;

[ApiController]
[Route("[controller]")]
public class PaymentsController : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public PaymentsController(IPaymentService paymentService) =>
        _paymentService = paymentService;

    [HttpGet()]
    public async Task<IActionResult> GetAllPayments(CancellationToken token = default)
    {
        var response = await _paymentService.GetAllPaymentsAsync(token);

        return Ok(response);
    }

    [HttpGet("{paymentId}")]
    public async Task<IActionResult> GetPayment(int paymentId, CancellationToken token = default)
    {
        var response = await _paymentService.GetPaymentAsync(paymentId, token);

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> RequestPayment(PaymentRequest request, CancellationToken token = default)
    {
        RequestValidator.ValidateExpiryDate(request.ExpiryDate);

        var response = await _paymentService.SendPaymentRequestAsync(request, token);

        return Ok(response);
    }
}
