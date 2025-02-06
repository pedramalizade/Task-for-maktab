using App.Domain.Core.DTOs;
using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Data.Repository
{
    public interface IDutyRepository
    {
        //public Task<List<Role>> GetRoles(CancellationToken cancellationToken);
        //public Task<User> Login(string username, string password, CancellationToken cancellationToken);
        public Task<List<GetDutyDto>> GetAllDuties(int id, CancellationToken cancellationToken);
        public Task<bool> CreateDuty(Duty duty, CancellationToken cancellationToken);
        public Task<bool> UpdateDuty(Duty duty, CancellationToken cancellationToken);
        public Task<bool> EndDuty(int id, CancellationToken cancellationToken);
        public Task<bool> DeleteDuty(int id, CancellationToken cancellationToken);
        public Task<Duty> GetDutyById(int id, CancellationToken cancellationToken);
        public Task<int> NumberDuty(int id, CancellationToken cancellationToken);
    }
}
