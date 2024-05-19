using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindMuse.Application.Contracts.Models.Requests
{
    public class AppointmentSlotRequest
    {
        public AppointmentSlotRequest()
        {
            AppointmentSlotId = Guid.NewGuid().ToString();
        }
        public string AppointmentSlotId { get; private set; }
        public string DoctorId { get; set; }
        public string ClinicId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool IsBooked { get; set; }
        public string? PatientId { get; set; }
    }
}
