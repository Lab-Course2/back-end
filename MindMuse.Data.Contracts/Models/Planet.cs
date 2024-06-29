using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindMuse.Data.Contracts.Models
{
    public class Planet
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string  Type { get; set; }
        public bool isDeleted {  get; set; }
    }
}
