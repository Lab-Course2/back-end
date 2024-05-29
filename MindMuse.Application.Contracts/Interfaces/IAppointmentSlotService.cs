using MindMuse.Application.Contracts.Models.Operations;
using MindMuse.Application.Contracts.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindMuse.Application.Contracts.Interfaces
{
    public interface IAppointmentSlotService
    {
        Task<AppointmentSlotRequest> GetAppointmentById(string id);
        Task<IEnumerable<AppointmentSlotRequest>> GetAllAppointmentSlots();
        Task<OperationResult> CreateAppointmentSlot(AppointmentSlotRequest appointmentSlot);
        Task<IEnumerable<AppointmentSlotRequest>> GetAppointmentSlotsByDoctorId(string stringid);
        Task<IEnumerable<AppointmentSlotRequest>> GetMyDoctorsAppointmentSlots(string clinicId);
        Task<OperationResult> CreateAppointmentSlotByWeeks(AppointmentSlotRequest appointmentSlot, int numberOfWeeks);
        Task<OperationResult> UpdateAppointmentSlot(string id, AppointmentSlotRequest appointmentSlot);
        Task<OperationResult> DeleteAsync(string id);
    }
}