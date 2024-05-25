using MindMuse.Application.Contracts.Models;
using MindMuse.Application.Contracts.Models.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindMuse.Data.Contracts.Interfaces
{

    public interface IRepository<T>
    {
        Task<string> GetIdByEmailAndPasswordAsync(string email, string password);
        Task<T> GetByIdAsync(string id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<OperationResult> AddAsync(T entity);
        Task<OperationResult> UpdateAsync(T entity);
        Task<OperationResult> DeleteAsync(string id);
        Task<IEnumerable<T>> GetDoctorsByClinicId(string clinicId);
    }
}