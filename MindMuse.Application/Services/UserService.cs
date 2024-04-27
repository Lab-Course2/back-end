using Microsoft.AspNetCore.Identity;
using MindMuse.Application.Contracts.Identity;
using MindMuse.Application.Contracts.Interfaces;
using MindMuse.Application.Contracts.Models.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindMuse.Application.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOperationResult _operationResult;
        private readonly IApplicationExtensions _applicationExtensions;

        public UserService(UserManager<ApplicationUser> userManager, IOperationResult operationResult, IApplicationExtensions applicationExtensions)
        {
            _userManager = userManager;
            _operationResult = operationResult;
            _applicationExtensions = applicationExtensions;
        }

        public async Task<Object> LogInAsync(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user != null)
            {
                var isPasswordValid = await _userManager.CheckPasswordAsync(user, password);

                if (isPasswordValid)
                {
                    var userRoles = await _userManager.GetRolesAsync(user);
                    var userRole = userRoles.FirstOrDefault();
                    var userId = user.Id;

                    var token = await _applicationExtensions.GenerateJwtTokenAsync(userId, username, userRole, new Dictionary<string, string>()
                    {
                         { "EmailConfirmation", user.EmailConfirmed.ToString() }
                    });

                    return token;
                }
            }
            return _operationResult.ErrorResult($"Failed to sign in:", new[] { "User not Found!" });
        }
    }
}