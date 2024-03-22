using System.ComponentModel.DataAnnotations;

namespace OnlineElectronicsStore.Domain.ViewModels.Account;

public class LoginViewModel
{
    [Required(ErrorMessage ="Не вказаний логін")]
    public string Login { get; set; }
         
    [Required(ErrorMessage = "Не вказаний пароль")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}