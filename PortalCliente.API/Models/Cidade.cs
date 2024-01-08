namespace PortalCliente.API.Models
{
    public class Cidade
    {
        public int Cod { get; set; }
        public string Nome { get; set; }

        public IList<Cliente> Cliente { get; set; }
    }
}
