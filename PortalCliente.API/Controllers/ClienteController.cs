using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalCliente.API.Data;
using PortalCliente.API.Models;
using PortalCliente.API.ViewModels;
using PortalCliente.API.ViewModels.Clientes;

namespace PortalCliente.API.Controllers
{
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet("v1/clientes")]
        public async Task<IActionResult> GetAsync([FromServices] DataContext context)
        {
            try
            {
                var clientes = await context.Clientes
                    .AsNoTracking()
                    .Include(x => x.Cidade)
                    .Select(x => new ListClientesViewModel
                    {
                        Cod = x.Cod,
                        Nome = x.Nome,
                        Email = x.Email,
                        Cidade = $"{x.Cidade.Nome}"
                    }).ToListAsync();

                return Ok(clientes);
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<List<Cliente>>("Falha ao consultar clientes"));
            }
        }
    }
}
