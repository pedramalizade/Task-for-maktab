using App.Domain.AppService.Duty;
using App.Domain.AppService.User;
using App.Domain.Core.AppService;
using App.Domain.Core.Config;
using App.Domain.Core.Data.Repository;
using App.Domain.Core.Entities;
using App.Domain.Core.Service;
using App.Domain.Services.Duty;
using App.Infra.Data.Ef.User;
using App.Infra.Data.SqlServer.Ef.ApplicationDbContext;
using Framework;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var siteSettings = configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();
builder.Services.AddSingleton(siteSettings);

// Add services to the container.
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




//builder.Services.AddIdentity<IdentityUser, IdentityRole>();
var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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


app.Run();
