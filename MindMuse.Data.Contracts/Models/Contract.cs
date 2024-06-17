using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindMuse.Data.Contracts.Models
{
    public class Contract
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }

      

    }
}
