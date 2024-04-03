using MindMuse.Application.Contracts.Models.Operations;
using MindMuse.Application.Contracts.ModelsRespond;
using MindMuse.Application.Contracts.Requests;

namespace MindMuse.Application.Contracts.Interfaces
{
    public interface IPatientService
    {
        Task<PatientResponse> GetPatitent(int patientId);
        Task<IEnumerable<PatientResponse>> GetAllPatitents();
        Task<OperationResult> CreatePatitentAsync(PatientRequest personDto);
        Task<OperationResult> UpdatePatitent(int personId, PatientRequest personDto);
        Task<OperationResult> DeletePatitent(int personId);
    }
}