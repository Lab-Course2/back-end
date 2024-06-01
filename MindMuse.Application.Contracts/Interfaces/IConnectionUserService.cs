using MindMuse.Application.Contracts.Models.Operations;
using MindMuse.Application.Contracts.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindMuse.Application.Contracts.Interfaces
{
    public interface IConnectionUserService
    {
        Task<OperationResult> AddConnection(ConnectionUserRequest connectionRequest);
        Task<IEnumerable<object>> GetAllConnections(string userId);
        Task<IEnumerable<ConnectionUserRequest>> GetAllConnections();
        Task<OperationResult> DeleteConnection(string userId, string friendId);
        Task<object> CheckIfExcist(string UserId, string DoctorId);

    }
}