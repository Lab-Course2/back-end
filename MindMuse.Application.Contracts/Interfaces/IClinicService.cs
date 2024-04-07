using MindMuse.Application.Contracts.Models.Operations;
using MindMuse.Application.Contracts.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindMuse.Application.Contracts.Interfaces
{
    public interface IClinicService
    {
        Task<ClinicRequest> GetClinic(string clinicId);
        Task<IEnumerable<ClinicRequest>> GetAllClinics();
        Task<OperationResult> CreateClinicAsync(ClinicRequest clinicDto);
        Task<OperationResult> UpdateClinic(string clinicId, ClinicRequest clinicDto);
        Task<OperationResult> DeleteClinic(string clinicId);
    }
}