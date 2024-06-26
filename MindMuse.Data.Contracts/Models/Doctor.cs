﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MindMuse.Application.Contracts.Identity;

namespace MindMuse.Data.Contracts.Models
{
    public partial class Doctor : ApplicationUser
    {
        public int PersonalNumber { get; set; }
        public string? Specialisation { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string? Description { get; set; }
        public string ClinicId { get; set; }
        public virtual Clinic Clinic { get; set; }
    }
}