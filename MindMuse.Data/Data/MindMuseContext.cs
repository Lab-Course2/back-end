﻿using MindMuse.Data.Contracts.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MindMuse.Application.Contracts.Identity;

namespace MindMuse.Data.Data
{
    public class MindMuseContext : IdentityDbContext<ApplicationUser>
    {
        public MindMuseContext()
        {
        }

        public MindMuseContext(DbContextOptions<MindMuseContext> options)
            : base(options)
        {
        }

        public DbSet<Admin> Admin { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Clinic> Clinic { get; set; }
        public DbSet<Doctor> Doctor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-EUO8BVU\\MSSQLSERVER01;Initial Catalog=MindMuse;Integrated Security=True; TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Admin>().ToTable("Admin");
            builder.Entity<Doctor>().ToTable("Doctor");
            builder.Entity<Clinic>().ToTable("Clinic");
            builder.Entity<Patient>().ToTable("Patient");

            // Adjust cascade behaviors for other relationships


            SeedRoles(builder);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole() { Name = "Clinic", ConcurrencyStamp = "2", NormalizedName = "Clinic" },
                new IdentityRole() { Name = "Doctor", ConcurrencyStamp = "3", NormalizedName = "Doctor" },
                new IdentityRole() { Name = "Patient", ConcurrencyStamp = "4", NormalizedName = "Patient" });
        }
    }

}