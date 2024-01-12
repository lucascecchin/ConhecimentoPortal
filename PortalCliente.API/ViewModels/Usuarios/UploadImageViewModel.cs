using System.ComponentModel.DataAnnotations;

namespace PortalCliente.API.ViewModels.Usuarios
{
    public class UploadImageViewModel
    {
        [Required(ErrorMessage = "Imagem inválida.")]
        public string Base64Image { get; set; }
    }
}
