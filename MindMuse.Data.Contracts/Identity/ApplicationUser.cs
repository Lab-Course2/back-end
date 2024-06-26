﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Text;
using System.Threading.Tasks;

namespace MindMuse.Application.Contracts.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string? Surname { get; set; }
        public string Role { get; set; }
        public string Address { get; set; }
        public string? PhotoData { get; set; }
        public string? PhotoFormat { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}