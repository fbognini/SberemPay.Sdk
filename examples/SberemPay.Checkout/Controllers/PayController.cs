using fbognini.Sdk.Exceptions;
using Microsoft.AspNetCore.Mvc;
using SberemPay.Sdk;
using SberemPay.Sdk.Requests;

namespace SberemPay.Checkout.Controllers;

public class PayController : Controller
{
    private readonly ILogger<PayController> _logger;
    private readonly ISberemPayApiService _sberemPayApiService;

    public PayController(ILogger<PayController> logger, ISberemPayApiService sberemPayApiService)
    {
        _logger = logger;
        _sberemPayApiService = sberemPayApiService;
    }

    [HttpPost]
    public async Task<ActionResult> Init()
    {

        var request = new CreatePaymentRequest
        {
            ReferenceId = Guid.NewGuid().ToString(),
            CustomerFirstName = "Mario",
            CustomerLastName = "Red",
            CustomerEmail = "mario.red@gmail.com",
            Lines = new List<CreatePaymentRequest.PaymentLine>()
            {
                new CreatePaymentRequest.PaymentLine()
                {
                    IsFood = true,
                    ProductImage = "https://source.unsplash.com/kcA-c3f_3FE",
                    Quantity = 1,
                    ProductName = "Fresh bowl",
                    UnitAmount = 700,
                }

            },
            Mode = Sdk.Models.Payments.PaymentMode.Payment,
            RedirectSuccessUrl = Url.Action("Success", "Pay", null, HttpContext.Request.Scheme)!,
            RedirectErrorUrl = Url.Action("Error", "Pay", null, HttpContext.Request.Scheme)!,
        };

        try
        {
            var payment = await _sberemPayApiService.CreatePayment(request);
            return new RedirectResult(payment.CheckoutUrl!);
        }
        catch (ApiException ex)
        {
            return BadRequest(ex.Response);
        }
    }

    public IActionResult Success()
    {
        return View();
    }

	public IActionResult Error()
    {
        return View();
    }
}