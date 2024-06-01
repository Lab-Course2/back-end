using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindMuse.Application.Contracts.Models.Requests
{
    public class ChatbotRequest
    {
        public string? UserId { get; set; }
        public string? Problem { get; set; }
        public string? Options { get; set; }
        public string? FreeTextQuestion { get; set; }
    }
}