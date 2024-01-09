using Elevor.Util;
using PortalCliente.API.Models;
using System.Security.Claims;

namespace PortalCliente.API.Extension
{
    public static class RoleClaimsExtension
    {
        public static IEnumerable<Claim> RetornaClaims(this Usuario usuario)
        {
            var result = new List<Claim>
            {
                new(ClaimTypes.Name, usuario.Email),
                new(ClaimTypes.Role, EnumHelper.RetornaDescricaoDoEnumerado(usuario.TipoUsuario))
            };            

            return result;
        }
    }
}
