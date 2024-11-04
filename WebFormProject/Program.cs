using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebFormProject.DAL.Abstract;
using WebFormProject.DAL.Concrete;
using WebFormProject.DAL.Configurations;
using WebFormProject.DAL.DbContexts;
using WebFormProject.Services.Abstract;
using WebFormProject.Services.Concrete;
using WebFromProject.Entities.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<WebFormDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddIdentity<AspNetUser, AspNetRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false; 
}).AddEntityFrameworkStores<WebFormDbContext>()
  .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IFormRepository, FormRepository>();
builder.Services.AddScoped<IFormService, FormService>();

builder.Services.AddScoped<IEntityTypeConfiguration<Form>, FormConfiguration>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
.AddCookie(options =>
{
    options.LoginPath = "/Account/Login"; // Giriþ yapmadýysa yönlendirileceði sayfa
});

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseDeveloperExceptionPage();

// Middleware yapýlandýrmasý
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
