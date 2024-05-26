using MindMuse.Application.Contracts.Models.Operations;
using MindMuse.Application.Contracts.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindMuse.Application.Contracts.Interfaces
{
    public interface IUserService
    {
        Task<Object> LogInAsync(string username, string password);
        Task<OperationResult> UserForgotPassword(string email);
        Task<OperationResult> UserResetPassword(PasswordRequest passwordRequest);
        Task<OperationResult> UserChangePassword(PasswordRequest passwordRequest);


    }
}