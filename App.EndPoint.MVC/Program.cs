var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var siteSettings = configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();
builder.Services.AddSingleton(siteSettings);

builder.Services.AddControllersWithViews();

builder.Services.AddIdentity<User, IdentityRole<int>>(option =>
{
    option.SignIn.RequireConfirmedAccount = false;
    option.Password.RequireDigit = false;
    option.Password.RequiredLength = 6;
    option.Password.RequireNonAlphanumeric = false;
    option.Password.RequireUppercase = false;
    option.Password.RequireLowercase = false;
    option.User.RequireUniqueEmail = true;

})

   .AddRoles<IdentityRole<int>>()
   .AddErrorDescriber<PersianIdentityErrorDescriber>()
   .AddEntityFrameworkStores<AppDbContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/User/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
});


builder.Services.AddScoped<IDutyService, DutyService>();
builder.Services.AddScoped<IDutyRepository, DutyRepository>();
builder.Services.AddScoped<IUserAppService, UserAppService>();
builder.Services.AddScoped<IDutyAppService, DutyAppService>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(siteSettings.ConnectionStrings.SqlConnection);
});

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

await SeedRolesAsync(app);
app.Run();

async Task SeedRolesAsync(IApplicationBuilder app)
{
    using var scope = app.ApplicationServices.CreateScope();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();

    string[] roles = { "Admin", "User" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole<int>(role));
        }
    }
}