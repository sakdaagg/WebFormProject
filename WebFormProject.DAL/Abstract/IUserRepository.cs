using Microsoft.AspNetCore.Identity;
using WebFromProject.Entities.Entities;
namespace WebFormProject.DAL.Abstract;

public interface IUserRepository
{
    Task<IdentityResult> AddUserAsync(AspNetUser user, string password);
    Task<AspNetUser?> GetUserAsync(string username, string password);
}
