using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindMuse.Application.Contracts.Models.Requests
{

    public class PasswordRequest
    {
        public string UserId { get; set; }
        public string? NewPassword { get; set; }
        public string? OldPassword { get; set; }

    }
}