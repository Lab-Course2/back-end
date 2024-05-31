using Microsoft.AspNetCore.Mvc;
using MindMuse.Application.Contracts.Models.Requests;
using MindMuse.Http.Contracts.Interfaces;
using MindMuse.Http.Contracts.Requests;

namespace MindMuse.AspNetCore.Controllers
{
    public class StripeController : ControllerBase
    {
        private readonly IStripeService _stripeService;

        public StripeController(IStripeService stripeService)
        {
            _stripeService = stripeService;
        }

        [HttpPost("charge")]
        public async Task<IActionResult> Charge([FromBody] PaymentRequest paymentRequest)
        {
            var clientSecret = await _stripeService.Charge(paymentRequest);
            return Ok(clientSecret);
        }

        [HttpPost("refund")]
        public async Task<IActionResult> Refund([FromBody] RefundRequest refundRequest)
        {
            var refund = await _stripeService.Refund(refundRequest);
            return Ok(refund);
        }
    }
}