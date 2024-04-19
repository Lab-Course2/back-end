using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindMuse.Application.Contracts.Models.Requests
{
    public class AdminRequest
    {
        public int PersonalNumber { get; set; }
        public DateOnly DateOfBirth { get; set; }
    }
}