using MindMuse.Data.Data;
using Microsoft.EntityFrameworkCore;
using MindMuse.Application.Contracts.Interfaces;
using MindMuse.Data.Contracts.Interfaces;
using MindMuse.Application.Contracts.Models.Operations;
using MindMuse.Data.Contracts.Models;

namespace MindMuse.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly MindMuseContext _context;

        public Repository(MindMuseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<string> GetIdByEmailAndPasswordAsync(string email, string password)
        {
            var user = await _context.Set<T>().FirstOrDefaultAsync(u =>
            EF.Property<string>(u, "Email") == email && EF.Property<string>(u, "Password") == password);

            if (user != null)
            {
                var userIdProperty = user.GetType().GetProperty("UserId");
                if (userIdProperty != null)
                {
                    var userId = userIdProperty.GetValue(user, null)?.ToString();
                    return userId;
                }
            }

            return null;
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<OperationResult> AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();

            return new OperationResult(true, "Added Successfully");
        }

        public async Task<OperationResult> UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new OperationResult(true, "Updated Successfully");
        }

        public async Task<OperationResult> DeleteAsync(string id)
        {
            var entity = await GetByIdAsync(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();

            return new OperationResult(true, "Entity deleted successfully");
        }
        public async Task<IEnumerable<T>> GetDoctorsByClinicId(string clinicId)
        {
            return (IEnumerable<T>)await Task.FromResult(_context.Doctor.Where(d => d.ClinicId == clinicId).ToList());
        }

        public async Task<IEnumerable<AppointmentSlot>> GetAppointmentSlotsByDoctorId(string doctorId)
        {
            return await Task.FromResult(_context.AppointmentSlot.Where(a => a.DoctorId == doctorId).ToList());
        }

        public async Task<IEnumerable<AppointmentSlot>> GetMyDoctorsAppointmentSlots(string clinicId)
        {
            return await Task.FromResult(_context.AppointmentSlot.Where(c => c.ClinicId == clinicId).ToList());
        }
        public async Task<string> GetPhoneNumberByIdAsync(string userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            return user?.PhoneNumber;
        }

    }
}