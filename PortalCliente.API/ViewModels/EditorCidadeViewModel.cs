using System.ComponentModel.DataAnnotations;

namespace PortalCliente.API.ViewModels
{
    public class EditorCidadeViewModel
    {
        [Required(ErrorMessage ="Nome é obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo deve ter entre 3 e 100 caracteres.")]
        public string Nome { get; set; }
    }
}
