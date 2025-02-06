using App.Domain.Core.Data.Repository;
using App.Domain.Core.DTOs;
using App.Domain.Core.Entities;
using App.Infra.Data.SqlServer.Ef.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Ef.User
{
    public class DutyRepository : IDutyRepository
    {
        private readonly AppDbContext _appDbContext;
        public DutyRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<bool> CreateDuty(Duty duty, CancellationToken cancellationToken)
        {
            await _appDbContext.Duties.AddAsync(duty);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteDuty(int id, CancellationToken cancellationToken)
        {
            var model = await _appDbContext.Duties.FirstOrDefaultAsync(x => x.Id == id);
            _appDbContext.Duties.Remove(model);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EndDuty(int id, CancellationToken cancellationToken)
        {
            var model = await _appDbContext.Duties.FirstOrDefaultAsync(x => x.Id == id);
            model.IsCompleted = true;
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<GetDutyDto>> GetAllDuties(int id, CancellationToken cancellationToken)
        {
            return await _appDbContext.Duties.AsNoTracking().Where(x => x.UserId == id)
                .Select(x => new GetDutyDto()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    IsCompleted = x.IsCompleted,

                }).ToListAsync();
        }

        public async Task<Duty> GetDutyById(int id, CancellationToken cancellationToken)
        {
            return await _appDbContext.Duties.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> NumberDuty(int id, CancellationToken cancellationToken)
        {
            var x = await _appDbContext.Duties.AsNoTracking().Where(x => x.UserId == id && x.IsCompleted == false).CountAsync();
            return x;
        }

        public async Task<bool> UpdateDuty(Duty duty, CancellationToken cancellationToken)
        {
            var taskU = await _appDbContext.Duties.FirstOrDefaultAsync(p => p.Id == duty.Id);
            taskU.Title = duty.Title;
            taskU.Description = duty.Description;
            taskU.IsCompleted = duty.IsCompleted;

            await _appDbContext.SaveChangesAsync();
            return true;
        }
    }
}
