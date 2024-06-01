using MindMuse.Data.Contracts.Models;
using MindMuse.Data.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MindMuse.Application.Contracts.Identity;
using MindMuse.Application.Contracts.Interfaces;
using MindMuse.Data.Repositories;
using MindMuse.Data.Contracts.Interfaces;

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


            serviceDescriptors.AddScoped<IRepository<Patient>, PatientRepository>();
            serviceDescriptors.AddScoped<IRepository<Admin>, AdminRepository>();
            serviceDescriptors.AddScoped<IRepository<Clinic>, ClinicRepository>();
            serviceDescriptors.AddScoped<IRepository<Doctor>, DoctorReporsitory>();
            serviceDescriptors.AddScoped<IRepository<ChatMessages>, ChatMessagesRepository>();
            serviceDescriptors.AddScoped<IRepository<AppointmentSlot>, AppointmentSlotRepository>();
            serviceDescriptors.AddScoped<IRepository<BookAppointment>, BookAppointmentRepository>();
            serviceDescriptors.AddScoped<IRepository<ConnectionRequests>, ConnectionRequestsRepository>();
            serviceDescriptors.AddScoped<IRepository<Connections>, ConnectionRepository>();
            serviceDescriptors.AddScoped<IChatMessagesRepository, ChatMessagesRepository>();
            serviceDescriptors.AddScoped<IRepository<ApplicationUser>, UsersRepository>();
            serviceDescriptors.AddScoped<IRepository<Appointment>, AppointmentRepository>();

        }
    }
}