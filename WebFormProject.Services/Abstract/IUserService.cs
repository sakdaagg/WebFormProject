using Microsoft.AspNetCore.Identity;
using WebFromProject.Entities.Entities;

namespace WebFormProject.Services.Abstract;
public interface IUserService
{
    Task<IdentityResult> RegisterUserAsync(AspNetUser user, string password);
    Task<AspNetUser?> AuthenticateAsync(string username, string password);
}
