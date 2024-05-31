using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MindMuse.Http.Contracts.Interfaces;
using MindMuse.Http.Services;
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
            serviceDescriptors.AddScoped<ITwilioService, TwilioService>();
            serviceDescriptors.AddScoped<IStripeApi, StripeService>();
        }
    }
}