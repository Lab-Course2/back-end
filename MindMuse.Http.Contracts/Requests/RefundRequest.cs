using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindMuse.Http.Contracts.Requests
{
    public class RefundRequest
    {
        public string PaymentIntentId { get; set; }
    }
}