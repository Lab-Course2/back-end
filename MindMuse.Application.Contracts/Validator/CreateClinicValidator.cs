﻿using FluentValidation;
using MindMuse.Application.Contracts.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindMuse.Application.Contracts.Validator
{
    public class CreateClinicValidator : AbstractValidator<ClinicRequest>
    {
        public CreateClinicValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username is required.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname is required.");
            RuleFor(x => x.Role).NotEmpty().WithMessage("Role is required.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.").EmailAddress().WithMessage("Invalid email format.");
            //RuleFor(x => x.Password)
            //    .NotEmpty().WithMessage("Password is required.")
            //    .MinimumLength(8).WithMessage("Password must have 8 characters or more.")
            //    .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
            //    .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
            //    .Matches("[0-9]").WithMessage("Password must contain at least one digit.")
            //    .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("PhoneNumber is required.");
            RuleFor(x => x.Location).NotEmpty().WithMessage("Location is required.");

            //RuleForEach(x => x.Doctors).SetValidator(new CreateDoctorValidator()); // Assuming you have a validator for DoctorRequest
        }
    }
}