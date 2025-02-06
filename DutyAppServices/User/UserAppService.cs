using App.Domain.Core.AppService;
using App.Domain.Core.Entities;
using App.Domain.Core.Service;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.User
{
    public class UserAppService : IUserAppService
    {
        private readonly UserManager<Core.Entities.User> _userManager;
        private readonly SignInManager<Core.Entities.User> _signInManager;
        public UserAppService(UserManager<Core.Entities.User> userManager, SignInManager<Core.Entities.User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> Login(string username, string password, CancellationToken cancellationToken)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, true, false);
            return result.Succeeded ? IdentityResult.Success : IdentityResult.Failed();
        }

        public async Task<IdentityResult> Register(Core.Entities.User user, CancellationToken cancellationToken)
        {
            var user1 = new Domain.Core.Entities.User
            {
                UserName = user.UserName,
                Email = user.Email,
                PasswordHash = user.PasswordHash
            };


            var result = await _userManager.CreateAsync(user, user.PasswordHash);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Admin");
            }

            return result;
        }
    }
}
