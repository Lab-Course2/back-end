using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MindMuse.Http.Contracts.Interfaces;
using MindMuse.Http.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MindMuse.Http.Validations
{
    public class StripeInjection
    {
        public static void AddApplicationServices(IServiceCollection serviceDescriptors, IConfiguration configuration)
        {
            serviceDescriptors.AddScoped<IStripeService, StripeService>();

        }
    }
}