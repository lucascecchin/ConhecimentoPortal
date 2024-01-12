using System.ComponentModel.DataAnnotations;

namespace PortalCliente.API.ViewModels.Usuarios
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail é inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [MinLength(5, ErrorMessage = "A senha deve ter no minimo 5 caracteres.")]
        public string Senha { get; set; }
    }
}
