namespace App.Domain.Core.AppService
{
    public interface IUserAppService
    {
        // public Task<List<Role>> GetRoles(CancellationToken cancellationToken);
        public Task<IdentityResult> Register(Core.Entities.User user, string password, CancellationToken cancellationToken);
        public Task<IdentityResult> Login(string username, string password, CancellationToken cancellationToken);
    }
}
