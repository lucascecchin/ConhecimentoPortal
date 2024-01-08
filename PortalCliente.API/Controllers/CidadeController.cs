using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalCliente.API.Data;
using PortalCliente.API.Extension;
using PortalCliente.API.Models;
using PortalCliente.API.ViewModels;

namespace PortalCliente.API.Controllers
{
    [ApiController]
    public class CidadeController : ControllerBase
    {
        [HttpGet("v1/cidades")]
        public async Task<IActionResult> GetAsync([FromServices] DataContext context)
        {
            try
            {
                var cidades = await context.Cidades.ToListAsync();
                return Ok(new ResultViewModel<List<Cidade>>(cidades));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<Cidade>>("Falha ao consultar cidades"));
            }

        }

        [HttpGet("v1/cidades/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id, [FromServices] DataContext context)
        {
            try
            {
                var cidade = await context.Cidades.FirstOrDefaultAsync(x => x.Cod == id);

                if (cidade == null)
                    return NotFound(new ResultViewModel<Cidade>("Cidade não encontrada."));

                return Ok(new ResultViewModel<Cidade>(cidade));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Cidade>("Falha ao consultar cidade"));
            }
        }

        [HttpPost("v1/cidades/")]
        public async Task<IActionResult> PostAsync([FromBody] EditorCidadeViewModel model, [FromServices] DataContext context)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<Cidade>(ModelState.GetErros()));

            try
            {
                var cidade = new Cidade { Nome = model.Nome };

                await context.Cidades.AddAsync(cidade);
                await context.SaveChangesAsync();

                return Created($"v1/cidades/{cidade.Cod}", new ResultViewModel<Cidade>(cidade));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<Cidade>("Não foi possível incluir a cidade."));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Cidade>("Falha interna no servidor."));
            }
        }

        [HttpPut("v1/cidades/{id:int}")]
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] EditorCidadeViewModel model, [FromServices] DataContext context)
        {
            try
            {
                var cidade = await context.Cidades.FirstOrDefaultAsync(x => x.Cod == id);

                if (cidade == null)
                    return NotFound(new ResultViewModel<Cidade>("Cidade não encontrada."));

                cidade.Nome = model.Nome;

                context.Cidades.Update(cidade);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<Cidade>(cidade));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<Cidade>("Não foi possível editar a cidade."));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Cidade>("Falha interna no servidor."));
            }
        }

        [HttpDelete("v1/cidades/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id, [FromServices] DataContext context)
        {
            try
            {
                var cidade = await context.Cidades.FirstOrDefaultAsync(x => x.Cod == id);

                if (cidade == null)
                    return NotFound(new ResultViewModel<Cidade>("Cidade não encontrada."));

                context.Cidades.Remove(cidade);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<Cidade>(cidade));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<Cidade>("Não foi possível deletar a cidade."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<Cidade>("Falha interna no servidor"));
            }
        }
    }
}
