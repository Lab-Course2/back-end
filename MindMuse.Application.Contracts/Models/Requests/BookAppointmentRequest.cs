using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindMuse.Application.Contracts.Models.Requests
{
    public class BookAppointmentRequest
    {
        public BookAppointmentRequest()
        {
            BookAppointmentId = Guid.NewGuid().ToString();
        }
        public string BookAppointmentId { get; private set; }
        public string AppointmentSlotId { get; set; }
        public string PatientId { get; set; }
        public string MeetingReason { get; set; }
        public string MeetingRequestDescription { get; set; }
        public string BookAppointmentStatus { get; set; }
        public DateTime? ResponseDateTime { get; set; } = DateTime.Now;
    }
}