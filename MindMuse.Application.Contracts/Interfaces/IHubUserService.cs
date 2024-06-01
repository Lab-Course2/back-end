using MindMuse.Application.Contracts.Models.Hub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindMuse.Application.Contracts.Interfaces
{
    public interface IHubUserService
    {
        Task AddUserToHub(HubUser user);
        Task<IEnumerable<HubUser>> GetAllUsers();
        Task RemoveUser(string userId);
    }
}