using Microsoft.AspNetCore.Identity;
using WebFormProject.DAL.Abstract;
using WebFormProject.Services.Abstract;
using WebFromProject.Entities.Entities;

namespace WebFormProject.Services.Concrete;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<AspNetUser?> AuthenticateAsync(string username, string password)
    {
        return await _userRepository.GetUserAsync(username, password);
    }

    public async Task<IdentityResult> RegisterUserAsync(AspNetUser user, string password)
    {
       return await _userRepository.AddUserAsync(user, password);
    }
}
