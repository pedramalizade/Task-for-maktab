using App.Domain.Core.DTOs;
using App.Domain.Core.Entities;
using App.Domain.Core.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppService
{
    public interface IDutyAppService
    {
        public Task<List<GetDutyDto>> GetAllDuties(int id, CancellationToken cancellationToken);
        public Task<Resultt> CreateDuty(Duty duty, CancellationToken cancellationToken);
        public Task<Resultt> UpdateDuty(Duty duty, CancellationToken cancellationToken);
        public Task<Resultt> EndDuty(int id, CancellationToken cancellationToken);
        public Task<Resultt> DeleteDuty(int id, CancellationToken cancellationToken);
        public Task<int> NumberDuty(int id, CancellationToken cancellationToken);
        public Task<Duty> GetDutyById(int id, CancellationToken cancellationToken);
    }
}

