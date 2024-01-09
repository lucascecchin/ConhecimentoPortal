using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalCliente.API.Data;
using PortalCliente.API.Extension;
using PortalCliente.API.Models;
using PortalCliente.API.Services;
using PortalCliente.API.ViewModels;
using SecureIdentity.Password;

namespace PortalCliente.API.Controllers
{
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private readonly TokenService _tokenService;

        public AutenticacaoController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("v1/registrar")]
        public async Task<IActionResult> Post([FromBody] RegisterViewModel model, [FromServices] DataContext context)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<string>(ModelState.GetErros()));

            var usuario = new Usuario
            {
                Nome = "Teste",
                Sobrenome = "teste",
                TipoUsuario = TipoUsuario.Administrador,
                Email = model.Email,
                Senha = PasswordHasher.Hash(model.Senha)
            };

            try
            {
                await context.Usuarios.AddAsync(usuario);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<dynamic>(new
                {
                    usuario = usuario.Email,
                    usuario.Senha
                }));
            }
            catch (DbUpdateException)
            {
                return StatusCode(400, new ResultViewModel<string>("Este e-mail já esta cadastrado."));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Cidade>("Falha interna no servidor"));
            }
        }

        [HttpPost("v1/login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model, [FromServices] DataContext context, [FromServices] TokenService tokenService)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<string>(ModelState.GetErros()));

            var usuario = await context.Usuarios.AsNoTracking().FirstOrDefaultAsync(x => x.Email == model.Email);

            if (usuario == null)
                return StatusCode(401, new ResultViewModel<string>("Usuário ou senha inválidos."));

            if(!PasswordHasher.Verify(usuario.Senha, model.Senha))
                return StatusCode(401, new ResultViewModel<string>("Usuário ou senha inválidos."));

            try
            {
                var token = tokenService.GenerateToken(usuario);

                return Ok(new ResultViewModel<string>(token, null));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Cidade>("Falha interna no servidor"));
            }

        }
    }
}
