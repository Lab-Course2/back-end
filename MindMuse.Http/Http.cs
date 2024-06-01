using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MindMuse.Http.Contracts.Interfaces;
using MindMuse.Http.Services;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindMuse.Http
{
    public class Http
    {
        public static void AddHttpModule(IServiceCollection serviceDescriptors, IConfiguration configuration)
        {
            serviceDescriptors.AddScoped<IStripeApi, StripeService>();
            serviceDescriptors.AddRefitClient<IStripeApi>().ConfigureHttpClient(c => c.BaseAddress = new Uri("https://api.stripe.com/api"));
            serviceDescriptors.AddScoped<ITwilioService, TwilioService>();
        }
    }
}