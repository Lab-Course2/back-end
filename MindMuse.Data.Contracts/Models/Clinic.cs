using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MindMuse.Application.Contracts.Identity;

namespace MindMuse.Data.Contracts.Models
{
    public partial class Clinic : ApplicationUser
    {
        public string? Location { get; set; }
        public DateOnly? CreatedDate { get; set; }
        public string? OtherDetails { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
    }
}