using Microsoft.Extensions.Configuration;
using MindMuse.Http.Contracts.Interfaces;
using MindMuse.Http.Contracts.Requests;
using Refit;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindMuse.Http.Services
{
    public class StripeService : IStripeApi
    {
        private readonly PaymentIntentService _paymentIntentService;

        public StripeService(IConfiguration configuration)
        {
            var secretKey = configuration.GetSection("Stripe:SecretKey").Value;
            StripeConfiguration.ApiKey = secretKey;
            _paymentIntentService = new PaymentIntentService();
        }

        public async Task<string> CreatePaymentIntent(PaymentIntentRequest paymentIntentRequest)
        {

            var options = new PaymentIntentCreateOptions
            {
                Amount = paymentIntentRequest.Amount,
                Currency = paymentIntentRequest.Currency,
                PaymentMethodTypes = paymentIntentRequest.PaymentMethodTypes,
                Customer = paymentIntentRequest.UserId,
                PaymentMethod = paymentIntentRequest.PaymentMethod

            };

            var paymentIntent = await _paymentIntentService.CreateAsync(options);
            var clientSecret = paymentIntent.ClientSecret;

            return clientSecret;
        }

        public async Task<string> RefundPayment(RefundRequest refundRequest)
        {


            var refundService = new RefundService();
            var refundOptions = new RefundCreateOptions
            {
                PaymentIntent = refundRequest.PaymentIntentId, // Retrieve Payment Intent ID from the dictionary using user ID
            };

            try
            {
                var refund = await refundService.CreateAsync(refundOptions);
                return refund.Id;
            }
            catch (StripeException ex)
            {
                // Handle Stripe exceptions here
                throw ex;
            }
        }
    }
}