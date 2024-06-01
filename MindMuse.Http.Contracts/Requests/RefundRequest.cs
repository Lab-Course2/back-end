using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindMuse.Http.Contracts.Requests
{
    public class RefundRequest
    {
        [Key]
        public string PaymentIntentId { get; set; }
    }
}