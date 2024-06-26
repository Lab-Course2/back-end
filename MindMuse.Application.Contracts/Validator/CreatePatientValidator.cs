﻿using FluentValidation;
using MindMuse.Application.Contracts.Models.Requests;
using System;
using System.Text.RegularExpressions;

namespace MindMuse.Application.Contracts.Validator
{
    public class CreatePatientValidator : AbstractValidator<PatientRequest>
    {
        public CreatePatientValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username is required.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname is required.");
            RuleFor(x => x.Role).NotEmpty().WithMessage("Role is required.");
            RuleFor(x => x.PersonalNumber).NotEmpty().WithMessage("PersonalNumber is required.");
            RuleFor(x => x.Email)
               .NotEmpty().WithMessage("Email is required.")
               .Matches(@"^[^\s@]+@[^\s@]+\.[^\s@]+(\.[^\s@]+)*$").WithMessage("Invalid email format.");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("PhoneNumber is required.");
            RuleFor(x => x.Gender).NotEmpty().WithMessage("Gender is required.");
            RuleFor(x => x.Password).Must(password => password == null || (password.Length >= 8
                                            && Regex.IsMatch(password, "[A-Z]")
                                            && Regex.IsMatch(password, "[a-z]")
                                            && Regex.IsMatch(password, "[0-9]")
                                            && Regex.IsMatch(password, "[^a-zA-Z0-9]"))).When(x => x.Password != null).WithMessage("Password must have 8 characters or more and contain at least one uppercase letter, one lowercase letter, one digit, and one special character.");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Address is required.");
            RuleFor(x => x.DateOfBirth)
                .NotEmpty().WithMessage("DateOfBirth is required.")
                .Must(BeAValidDate).WithMessage("DateOfBirth must be a valid date in the format yyyy-MM-dd.")
                .Must(BeAtLeast18YearsOld).WithMessage("You must be at least 18 years old.");
        }

        private bool BeAValidDate(string date)
        {
            return DateTime.TryParseExact(date, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out _);
        }

        private bool BeAtLeast18YearsOld(string date)
        {
            if (DateTime.TryParseExact(date, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out var dateOfBirth))
            {
                var today = DateTime.Today;
                var age = today.Year - dateOfBirth.Year;

                if (dateOfBirth.Date > today.AddYears(-age)) age--;

                return age >= 18;
            }
            return false;
        }
    }
}
