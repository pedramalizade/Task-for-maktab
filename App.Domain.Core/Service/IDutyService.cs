namespace App.Domain.Core.Service
{
    public interface IDutyService
    {
        public Task<List<GetDutyDto>> GetAllDuties(int id, CancellationToken cancellationToken);
        public Task<bool> CreateDuty(Duty duty, CancellationToken cancellationToken);
        public Task<bool> UpdateDuty(Duty duty, CancellationToken cancellationToken);
        public Task<bool> EndDuty(int id, CancellationToken cancellationToken);
        public Task<bool> DeleteDuty(int id, CancellationToken cancellationToken);
        public Task<Duty> GetDutyById(int id, CancellationToken cancellationToken);
        public Task<int> NumberDuty(int id, CancellationToken cancellationToken);
    }
}
