using MindMuse.Application.Contracts.Models.Operations;
using MindMuse.Application.Contracts.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindMuse.Application.Contracts.Interfaces
{
    public interface IAppointmentService
    {
        Task<AppointmentRequest> GetAppointment(string id);
        Task<IEnumerable<AppointmentRequest>> GetAllAppointments();
        Task<OperationResult> DeleteAppointment(string id);
        Task<OperationResult> CreateAppointment(AppointmentRequest request);
        Task<OperationResult> AcceptAppointment(string id);
        Task<OperationResult> DeclineAppointment(string id);
        Task<OperationResult> DoctorCancelAppointment(string id);
        Task<OperationResult> PatientCancelAppointment(string id);
        Task<OperationResult> PatientCancelAppointmentPostMethod(string id);
    }
}