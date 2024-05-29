using MindMuse.Data.Contracts.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindMuse.Data
{
    //    public class AppointmentMongoService
    //    {
    //        private readonly IMongoCollection<Appointment> _appointments;

    //        public AppointmentMongoService(IMongoDatabase database)
    //        {
    //            _appointments = database.GetCollection<Appointment>("Appointments");
    //        }

    //        public async Task<List<Appointment>> GetAsync() =>
    //            await _appointments.Find(appointment => true).ToListAsync();

    //        public async Task<Appointment> GetAsync(string id) =>
    //            await _appointments.Find<Appointment>(appointment => appointment.AppointmentId == id).FirstOrDefaultAsync();

    //        public async Task CreateAsync(Appointment appointment) =>
    //            await _appointments.InsertOneAsync(appointment);

    //        public async Task UpdateAsync(string id, Appointment updatedAppointment) =>
    //            await _appointments.ReplaceOneAsync(appointment => appointment.AppointmentId == id, updatedAppointment);

    //        public async Task RemoveAsync(string id) =>
    //            await _appointments.DeleteOneAsync(appointment => appointment.AppointmentId == id);
    //    }
 
}