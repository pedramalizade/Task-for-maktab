using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppService
{
    public interface IUserAppService
    {
        // public Task<List<Role>> GetRoles(CancellationToken cancellationToken);
        public Task<IdentityResult> Register(User user, CancellationToken cancellationToken);
        public Task<IdentityResult> Login(string username, string password, CancellationToken cancellationToken);
    }
}
