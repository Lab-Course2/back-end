﻿using MindMuse.Application.Contracts.Interfaces;
using MindMuse.Application.Mapper;
using MindMuse.Application.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MindMuse.Application.Contracts.Validator;
using MindMuse.Application.Contracts.Common;
using MindMuse.Application.Contracts.Models.Requests;
using MindMuse.Application.Contracts.Models.Operations;
using Microsoft.Extensions.Configuration;
using MindMuse.Application.Contracts.Models.EmailConfig;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;


namespace MindMuse.Application
{
    public static class ApplicationInjection
    {
        public static void AddApplicationServices(this IServiceCollection serviceDescriptors, IConfiguration configuration)
        {
            serviceDescriptors.AddAutoMapper(typeof(MappingProfile));
            serviceDescriptors.AddScoped<IUserService, UserService>();
            serviceDescriptors.AddTransient<IValidator<PatientRequest>, CreatePatientValidator>();
            serviceDescriptors.AddTransient<IValidator<DoctorRequest>, CreateDoctorValidator>();
            serviceDescriptors.AddScoped<IApplicationExtensions, ApplicationExtensions>();
            serviceDescriptors.AddScoped<IPatientService, PatientService>();
            serviceDescriptors.AddSingleton<IOperationResult, OperationResult>();
            serviceDescriptors.AddScoped<IEmailSerivces, EmailService>();



            serviceDescriptors.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            serviceDescriptors.AddScoped<IUrlHelper>(serviceProvider =>
            {
                var actionContext = serviceProvider.GetRequiredService<IActionContextAccessor>().ActionContext;
                return new UrlHelper(actionContext);
            });



            serviceDescriptors.AddHttpContextAccessor();
            serviceDescriptors.Configure<IdentityOptions>(
                opt => opt.SignIn.RequireConfirmedEmail = true);


            serviceDescriptors.AddScoped<IEmailSerivces, EmailService>();


            var emailConfig = configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
            serviceDescriptors.AddSingleton(emailConfig);
        }
    }
}