using MindMuse.Application.Contracts.Identity;
using Microsoft.AspNetCore.Identity;
using MindMuse.Application.Contracts.Requests;
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


namespace MindMuse.Application
{
    public static class ApplicationInjection

    {
        public static void AddApplicationServices(this IServiceCollection serviceDescriptors)
        {

            serviceDescriptors.AddAutoMapper(typeof(MappingProfile));
            serviceDescriptors.AddTransient<IValidator<PatientRequest>, CreatePatientValidator>();
            serviceDescriptors.AddScoped<IApplicationExtensions, ApplicationExtensions>();
            serviceDescriptors.AddScoped<IPatientService, PatientService>();
            serviceDescriptors.AddSingleton<IOperationResult, OperationResult>();

        }
    }
}