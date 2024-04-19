using MindMuse.Application.Contracts.Identity;
using Microsoft.AspNetCore.Identity;
using MindMuse.Application.Contracts.Validator;
using MindMuse.Application.Contracts.Co;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using MindMuse.Data.Data;
using MindMuse.Application.Contracts.Interfaces;
using MindMuse.Application.Services;
using MindMuse.Application.Mapper;
using MindMuse.Application.Contracts.Common;
using MindMuse.Application.Contracts.Models.Operations;
using MindMuse.Application.Contracts.Models.Requests;


namespace MindMuse.Application
{
    public static class ApplicationInjection
    {
        public static void AddApplicationServices(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddAutoMapper(typeof(MappingProfile));
            serviceDescriptors.AddScoped<IUserService, UserService>();
            serviceDescriptors.AddTransient<IValidator<PatientRequest>, CreatePatientValidator>();
            serviceDescriptors.AddTransient<IValidator<DoctorRequest>, CreateDoctorValidator>();
            serviceDescriptors.AddScoped<IApplicationExtensions, ApplicationExtensions>();
            serviceDescriptors.AddScoped<IPatientService, PatientService>();
            serviceDescriptors.AddSingleton<IOperationResult, OperationResult>();
            serviceDescriptors.AddScoped<IClinicService, ClinicService>();
            serviceDescriptors.AddScoped<IDoctorService, DoctorService>();
            serviceDescriptors.AddTransient<IValidator<ClinicRequest>, CreateClinicValidator>();
        }
    }
}