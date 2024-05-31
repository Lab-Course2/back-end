﻿using MindMuse.Http.Contracts.Requests;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MindMuse.Http.Contracts.Interfaces
{
    public interface IStripeApi
    {
        [Post("/v1/charges")]
        Task<string> Charge([Body] PaymentRequest paymentRequest);

        [Post("/v1/refund")]
        Task<string> Refund([Body] RefundRequest refundRequest);
    }
}