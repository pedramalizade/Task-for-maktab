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

        public async Task<IdentityResult> Register(Core.Entities.User user, string password, CancellationToken cancellationToken)
        {
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Admin");
            }

            return result;
        }
    }
}
