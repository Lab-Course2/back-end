using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindMuse.Application.Contracts.Models.Requests
{
    public class ConnectionUserRequest
    {
        public string? ConnectionId { get; set; } = Guid.NewGuid().ToString();
        public string FromId { get; set; }
        public string ToId { get; set; }
        public DateTime dateTimestamp { get; set; }
    }
}