using MindMuse.Application.Contracts.ModelsRespond;
using MindMuse.Data.Contracts.Models;
using AutoMapper;
using MindMuse.Application.Contracts.Requests;
using MindMuse.Application.Contracts.Identity;

namespace MindMuse.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TblAdmin, AdminRequest>().ReverseMap();
            CreateMap<TblClinic, ClinicRequest>().ReverseMap();
            CreateMap<TblDoctor, DoctorRequest>().ReverseMap();
            CreateMap<TblPatient, PatientRequest>().ReverseMap();
            CreateMap<TblPatient, PatientResponse>();
            CreateMap<PatientRequest, ApplicationUser>();

        }
    }
}