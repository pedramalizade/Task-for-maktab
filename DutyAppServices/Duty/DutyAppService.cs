using App.Domain.Core.AppService;
using App.Domain.Core.Config;
using App.Domain.Core.DTOs;
using App.Domain.Core.Result;
using App.Domain.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.Duty
{
    public class DutyAppService : IDutyAppService
    {
        private readonly IDutyService _dutyService;
        private readonly SiteSettings _SiteSettings;

        public DutyAppService(IDutyService dutyService, SiteSettings siteSettings)
        {
            _dutyService = dutyService;
            _SiteSettings = siteSettings;
        }
        public async Task<Resultt> CreateDuty(Core.Entities.Duty duty, CancellationToken cancellationToken)
        {
            if (await _dutyService.NumberDuty(duty.UserId, cancellationToken) >= _SiteSettings.NumberUnfinishedTasks)
            {
                return new Resultt(false, " تعداد وظایف ناتمام شما بیش از مقدار تعیین شده است..");
            }
            else
            {
                await _dutyService.CreateDuty(duty, cancellationToken);
                return new Resultt(true, "با موفقیت اضافه شد.");
            }
        }

        public async Task<Resultt> DeleteDuty(int id, CancellationToken cancellationToken)
        {
            if (await _dutyService.GetDutyById(id, cancellationToken) != null)
            {
                await _dutyService.DeleteDuty(id, cancellationToken);
                return new Resultt(true, "با موفقیت حذف شد.");
            }
            else
                return new Resultt(false, " همچین وظیفه ای وجود ندارد.");
        }

        public async Task<Resultt> EndDuty(int id, CancellationToken cancellationToken)
        {
            if (await _dutyService.GetDutyById(id, cancellationToken) != null)
            {
                await _dutyService.EndDuty(id, cancellationToken);
                return new Resultt(true, "با موفقیت به پایان رسید.");
            }
            else
            {
                return new Resultt(false, "همچین وظیفه ای وجود ندارد.");
            }
        }

        public async Task<List<GetDutyDto>> GetAllDuties(int id, CancellationToken cancellationToken)
        {
           return await _dutyService.GetAllDuties(id, cancellationToken);
        }

        public async Task<Core.Entities.Duty> GetDutyById(int id, CancellationToken cancellationToken)
        {
            if (await _dutyService.GetDutyById(id, cancellationToken) != null)
            {
                return await _dutyService.GetDutyById(id, cancellationToken);

            }
            else
                return null;
        }

        public async Task<int> NumberDuty(int id, CancellationToken cancellationToken)
        {
            return await _dutyService.NumberDuty(id, cancellationToken);
        }

        public async Task<Resultt> UpdateDuty(Core.Entities.Duty duty, CancellationToken cancellationToken)
        {
            if (await _dutyService.GetDutyById(duty.Id, cancellationToken) != null)
            {
                await _dutyService.UpdateDuty(duty, cancellationToken);
                return new Resultt(true, "با موفقیت ویرایش شد.");
            }
            else
                return new Resultt(false, "همچین وظیفه ای وجود ندارد.");
        }
    }
}
