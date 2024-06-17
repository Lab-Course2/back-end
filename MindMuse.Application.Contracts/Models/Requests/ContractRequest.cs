using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindMuse.Application.Contracts.Models.Requests
{
    public class ContractRequest
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public int EmployeeId { get; set; }
    }
}
