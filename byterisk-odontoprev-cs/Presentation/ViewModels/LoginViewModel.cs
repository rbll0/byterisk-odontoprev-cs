using System.ComponentModel.DataAnnotations;

namespace byterisk_odontoprev_cs.Presentation.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "O e-mail é obrigatório")]
    [EmailAddress(ErrorMessage = "Digite um e-mail válido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "A senha é obrigatória")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
