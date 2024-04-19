using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MindMuse.Application.Contracts.Identity;

namespace MindMuse.Data.Contracts.Models;

public partial class Admin : ApplicationUser
{ 
    public string? Test { get; set; }
    public int PersonalNumber { get; set; }
    public DateOnly DateOfBirth { get; set; }

}