﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindMuse.Data.Contracts.Models
{
    public class Satellite
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
       public bool IsDeleted { get; set; }
        [ForeignKey("PlanetId")]
        public int PlanetId { get; set; }
    }
}
