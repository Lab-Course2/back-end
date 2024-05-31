﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindMuse.Application.Contracts.Models.Requests
{

    public class AppointmentRequest
    {
        public AppointmentRequest()
        {
            AppointmentId = Guid.NewGuid().ToString();
        }

        public string AppointmentId { get; private set; }
        public string BookAppointmentId { get; set; }
        public string Status { get; set; }
        public virtual BookAppointmentRequest BookAppointment { get; set; } // Assuming BookAppointmentRequest is the type you want to set here
        public virtual AppointmentSlotRequest AppointmentSlot { get; set; }

        public void SetBookAppointment(BookAppointmentRequest bookAppointment)
        {
            BookAppointment = bookAppointment;
        }
        public void SetAppointmentSlot(AppointmentSlotRequest appointmentSlot)
        {
            AppointmentSlot = appointmentSlot;
        }
    }
}