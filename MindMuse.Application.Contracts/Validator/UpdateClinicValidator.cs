﻿using FluentValidation;
using MindMuse.Application.Contracts.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MindMuse.Application.Contracts.Validator
{
    public class UpdateClinicValidator : AbstractValidator<ClinicRequest>
    {
        public UpdateClinicValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username is required.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(x => x.Role).NotEmpty().WithMessage("Role is required.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.").EmailAddress().WithMessage("Invalid email format.");
            RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .Matches(@"^[^\s@]+@[^\s@]+\.[^\s@]+(\.[^\s@]+)*$").WithMessage("Invalid email format.");

            RuleFor(x => x.Password)
                .Must(password => password == null || (password.Length >= 8
                                                        && Regex.IsMatch(password, "[A-Z]")
                                                        && Regex.IsMatch(password, "[a-z]")
                                                        && Regex.IsMatch(password, "[0-9]")
                                                        && Regex.IsMatch(password, "[^a-zA-Z0-9]")))
                .When(x => x.Password != null)
                .WithMessage("Password must have 8 characters or more and contain at least one uppercase letter, one lowercase letter, one digit, and one special character.");

            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("PhoneNumber is required.");
            RuleFor(x => x.Location).NotEmpty().WithMessage("Location is required.");
        }
    }
}