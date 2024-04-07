﻿using MindMuse.Data.Contracts.Models;
using AutoMapper;
using MindMuse.Application.Contracts.Identity;
using MindMuse.Application.Contracts.Models.Requests;
using System.Numerics;

namespace MindMuse.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Patient, PatientRequest>().ReverseMap();
            CreateMap<Admin, AdminRequest>().ReverseMap();
            CreateMap<Clinic, ClinicRequest>().ReverseMap();
            CreateMap<Doctor, DoctorRequest>().ReverseMap().ReverseMap().ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<ApplicationUser, PatientRequest>().ReverseMap();
            CreateMap<Patient, ApplicationUser>();
            CreateMap<Clinic, ApplicationUser>();
            CreateMap<DoctorRequest, ApplicationUser>().ReverseMap();
        }
    }
}