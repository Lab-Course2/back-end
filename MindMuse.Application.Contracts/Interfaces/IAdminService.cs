using MindMuse.Application.Contracts.Models.Request;
using MindMuse.Application.Contracts.Models.Operations;

namespace MindMuse.Application.Contracts.Interfaces
{
    public interface IAdminService
        {
            Task<AdminRequest> GetAdmin(string adminId);
            Task<IEnumerable<AdminRequest>> GetAllAdmins();
            Task<OperationResult> CreateAdminAsync(AdminRequest personDto);
            Task<OperationResult> UpdateAdmin(string personId, AdminRequest personDto);
            Task<OperationResult> DeleteAdmin(string personId);
            Task<OperationResult> ConfirmEmail(string token, string email);
        }
}