﻿using MindMuse.Application.Contracts.Interfaces;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MindMuse.Application.Contracts.Validator;
using MindMuse.Application.Contracts.Models.Request;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using MindMuse.Application.Mapper;
using MindMuse.Application.Contracts.Interfaces;
using MindMuse.Application.Services;
using MindMuse.Application.Contracts.Models.Requests;
using MindMuse.Application.Contracts.Common;
using MindMuse.Application.Contracts.Validator;
using MindMuse.Application.Contracts.Models.Operations;
using MindMuse.Application.Services;
using MindMuse.Application.Contracts.Models.EmailConfig;
using MindMuse.Data.Contracts.Interfaces;
using MindMuse.Data.Contracts.Models;
using MindMuse.Data.Repositories;

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
            serviceDescriptors.AddScoped<IDoctorService, DoctorService>();
            serviceDescriptors.AddScoped<IPatientService, PatientService>();
            serviceDescriptors.AddScoped<IApplicationExtensions, ApplicationExtensions>();
            serviceDescriptors.AddSingleton<IOperationResult, OperationResult>();
            serviceDescriptors.AddScoped<IEmailServices, EmailService>();
            serviceDescriptors.AddScoped<IClinicService, ClinicService>();
            serviceDescriptors.AddTransient<IValidator<ClinicRequest>, CreateClinicValidator>();
            serviceDescriptors.AddSingleton<IConfiguration>(configuration);
            serviceDescriptors.AddScoped<IAdminService, AdminService>();
            serviceDescriptors.AddTransient<IValidator<AdminRequest>, CreateAdminValidator>();
            serviceDescriptors.AddTransient<IValidator<ClinicRequest>, UpdateClinicValidator>();
            serviceDescriptors.AddScoped<IAppointmentSlotService, AppointmentSlotService>();
            serviceDescriptors.AddTransient<IValidator<AppointmentSlotRequest>, CreateAppointmentSlotValidator>();
            serviceDescriptors.AddScoped<IRepository<AppointmentSlot>, AppointmentSlotRepository>();
            serviceDescriptors.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            serviceDescriptors.AddTransient<IValidator<PasswordRequest>, ValidatorPasswordRequest>();
            serviceDescriptors.AddScoped<IUrlHelper>(serviceProvider =>
            {
                var actionContext = serviceProvider.GetRequiredService<IActionContextAccessor>().ActionContext;
                return new UrlHelper(actionContext);
            });


            serviceDescriptors.Configure<IdentityOptions>(
                opt => opt.SignIn.RequireConfirmedEmail = true);


            serviceDescriptors.AddHttpContextAccessor();
            serviceDescriptors.Configure<IdentityOptions>(
                opt => opt.SignIn.RequireConfirmedEmail = true);


            serviceDescriptors.AddScoped<IEmailServices, EmailService>();


            var emailConfig = configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
            serviceDescriptors.AddSingleton(emailConfig);
        }
    }
}