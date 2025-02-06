using App.Domain.Core.Data.Repository;
using App.Domain.Core.DTOs;
using App.Domain.Core.Entities;
using App.Domain.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Duty
{
    public class DutyService : IDutyService
    {
        private readonly IDutyRepository _dutyRepository;
        public DutyService(IDutyRepository dutyRepository)
        {
            _dutyRepository = dutyRepository;
        }

        public async Task<bool> CreateDuty(Core.Entities.Duty duty, CancellationToken cancellationToken)
        {
            await _dutyRepository.CreateDuty(duty, cancellationToken);
            return true;
        }

        public async Task<bool> DeleteDuty(int id, CancellationToken cancellationToken)
        {
            await _dutyRepository.DeleteDuty(id, cancellationToken);
            return true;
        }

        public async Task<bool> EndDuty(int id, CancellationToken cancellationToken)
        {
            await _dutyRepository.EndDuty(id, cancellationToken);
            return true;
        }

        public async Task<List<GetDutyDto>> GetAllDuties(int id, CancellationToken cancellationToken)
        {
            return await _dutyRepository.GetAllDuties(id, cancellationToken);
        }

        public async Task<Core.Entities.Duty> GetDutyById(int id, CancellationToken cancellationToken)
        {
            return await _dutyRepository.GetDutyById(id, cancellationToken);
        }

        public async Task<int> NumberDuty(int id, CancellationToken cancellationToken)
        {
            return await _dutyRepository.NumberDuty(id, cancellationToken);
        }

        public async Task<bool> UpdateDuty(Core.Entities.Duty duty, CancellationToken cancellationToken)
        {
            await _dutyRepository.UpdateDuty(duty, cancellationToken);
            return true;
        }
    }
}
