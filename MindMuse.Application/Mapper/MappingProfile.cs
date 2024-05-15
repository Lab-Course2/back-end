using MindMuse.Data.Contracts.Models;
using AutoMapper;
using MindMuse.Application.Contracts.Identity;
using MindMuse.Application.Contracts.Models.Requests;
using System.Numerics;
using MindMuse.Application.Contracts.Models.Request;

namespace MindMuse.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Patient, PatientRequest>().ReverseMap().ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<Admin, AdminRequest>().ReverseMap().ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<Doctor, DoctorRequest>().ReverseMap().ReverseMap().ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<ApplicationUser, PatientRequest>().ReverseMap();
            CreateMap<Clinic, ApplicationUser>();
            CreateMap<DoctorRequest, ApplicationUser>().ReverseMap();
            CreateMap<Clinic, ClinicRequest>().ReverseMap().ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<ApplicationUser, PatientRequest>().ReverseMap();
            CreateMap<Patient, ApplicationUser>().ReverseMap();
            CreateMap<Clinic, ApplicationUser>().ReverseMap();
            CreateMap<ApplicationUser, AdminRequest>().ReverseMap();
        }
    }
}