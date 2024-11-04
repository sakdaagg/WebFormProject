using System.ComponentModel.DataAnnotations;

namespace WebFormProject.Models;

public class RegisterViewModel
{

    [Required(ErrorMessage = "Ad gereklidir")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Soyad gereklidir")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Kullanıcı adı gereklidir")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Email gereklidir")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Şifre gereklidir")]
    public string Password { get; set; }

    [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor")]
    public string ConfirmPassword { get; set; }
}
