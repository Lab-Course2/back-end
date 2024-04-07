using MindMuse.Application.Contracts.Models.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindMuse.Application.Contracts.Interfaces
{
    public interface IUserService
    {
        Task<OperationResult> LogInAsync(string username, string password);
    }
}
