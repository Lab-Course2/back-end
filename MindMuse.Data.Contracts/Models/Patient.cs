using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MindMuse.Application.Contracts.Identity;

namespace MindMuse.Data.Contracts.Models;

public partial class Patient : ApplicationUser
{
    public int PersonalNumber { get; set; }
    public string Gender { get; set; }
    public string Description { get; set; }
    public DateTime DateOfBirth { get; set; }

}