using Microsoft.AspNetCore.Identity;
using WebFormProject.DAL.Abstract;
using WebFromProject.Entities.Entities;

namespace WebFormProject.DAL.Concrete;

public class UserRepository : IUserRepository
{

    private readonly UserManager<AspNetUser> _userManager;
    private readonly SignInManager<AspNetUser> _signInManager;
    public UserRepository(UserManager<AspNetUser> userManager, SignInManager<AspNetUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }
    public async Task<AspNetUser?> GetUserAsync(string username, string password)
    {
        var user = await _userManager.FindByNameAsync(username);
        if (user != null)
        {
            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            return result.Succeeded ? user : null;
        }
        return null;
    }

    public async Task<IdentityResult> AddUserAsync(AspNetUser user, string password)
    {
        try
        {
            var result = await _userManager.CreateAsync(user, password);
            return result;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
