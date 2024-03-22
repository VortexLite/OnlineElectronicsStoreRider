using System.ComponentModel.DataAnnotations;

namespace OnlineElectronicsStore.Domain.ViewModels.Account;

public class RegisterViewModel
{
    [Required(ErrorMessage ="Не вказаний логін")]
    public string Login { get; set; }
         
    [Required(ErrorMessage = "Не вказаний пароль")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
         
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Паролі відрізняються")]
    public string ConfirmPassword { get; set; }
}