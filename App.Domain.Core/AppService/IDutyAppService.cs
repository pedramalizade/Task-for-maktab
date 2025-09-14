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

