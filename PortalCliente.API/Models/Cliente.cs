using System.ComponentModel.DataAnnotations.Schema;

namespace PortalCliente.API.Models
{
    public class Cliente
    {
        public int Cod { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        [ForeignKey("Cidade")]
        public int CodCidades { get; set; }

        public virtual Cidade Cidade { get; set; }

    }
}
