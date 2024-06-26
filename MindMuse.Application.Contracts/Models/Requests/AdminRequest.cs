﻿using System.ComponentModel.DataAnnotations;

namespace MindMuse.Application.Contracts.Models.Request
{
    public class AdminRequest
    {
        public AdminRequest()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; private set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Role { get; set; }
        public int PersonalNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? PhotoData { get; set; }
        public string? PhotoFormat { get; set; }
    }
}