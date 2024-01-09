using System.ComponentModel;

namespace PortalCliente.API.Models
{
    public class Usuario
    {
        public int Cod { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public TipoUsuario TipoUsuario { get; set; }

    }
       
    public enum TipoUsuario
    {
        [Description("Usuário")]
        Usuario = 1,
        [Description("Administrador")]
        Administrador = 2,
    }
}
