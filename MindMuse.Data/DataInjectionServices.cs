using MindMuse.Data.Contracts.Models;
using MindMuse.Data.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MindMuse.Application.Contracts.Identity;
using MindMuse.Application.Contracts.Interfaces;
using MindMuse.Data.Repositories;
using AppointEase.Data.Repositories;

namespace MindMuse.Data
{
    public static class DataInjectionServices
    {
        public static void AddDataServices(this IServiceCollection serviceDescriptors, IConfiguration configuration)
        {
            serviceDescriptors.AddDbContext<MindMuseContext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")
                );
            });

            serviceDescriptors.AddIdentity<ApplicationUser, IdentityRole>()
                 .AddEntityFrameworkStores<MindMuseContext>()
                 .AddDefaultTokenProviders();

            serviceDescriptors.AddScoped<MindMuseContext>();
            serviceDescriptors.AddScoped<IRepository<TblPatient>, UserRepository>();
            serviceDescriptors.AddScoped<IRepository<TblAdmin>, AdminRepository>();
            serviceDescriptors.AddScoped<IRepository<TblClinic>, ClinicRepository>();
            serviceDescriptors.AddScoped<IRepository<TblDoctor>, DoctorReporsitory>();

        }
    }
}