using System.ComponentModel.DataAnnotations;

namespace WebFormProject.Models;

public class LoginViewModel
{
    [Required(ErrorMessage = "Kullanıcı adı gereklidir")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Şifre gereklidir")]
    public string Password { get; set; }
}
