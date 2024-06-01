using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindMuse.Application.Contracts.Models.Hub
{
    public class HubUser
    {
        public string UserId { get; set; }
        public string ConnectionId { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}