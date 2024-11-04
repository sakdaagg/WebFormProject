using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebFormProject.DAL.Abstract;
using WebFormProject.DAL.Concrete;
using WebFormProject.DAL.DbContexts;
using WebFormProject.Services.Abstract;
using WebFormProject.Services.Concrete;
using WebFromProject.Entities.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<WebFormDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<AspNetUser, AspNetRole>()
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<WebFormDbContext>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddControllersWithViews();

builder.Services.AddAuthorization();

var app = builder.Build();

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
