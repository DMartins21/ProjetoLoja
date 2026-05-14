using System.ComponentModel.DataAnnotations;

namespace ProjetoLoja.ViewModel;

public class LoginViewModel
{
    [Required(ErrorMessage = "Informe Seu Usuário")]
    [Display(Name = "Usuário")]
    public string UserName { get; set; }
    [Required(ErrorMessage = "Informe a Senha")]
    [DataType(DataType.Password)]
    [Display(Name = "Senha")]
    public string Password { get; set; }
    public string ReturnUrl { get; set; }
}