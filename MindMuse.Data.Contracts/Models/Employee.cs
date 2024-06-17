using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindMuse.Data.Contracts.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public string FullName { get; set; }
        public bool IsActive { get; set; }
    }
}
