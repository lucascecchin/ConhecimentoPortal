using Microsoft.AspNetCore.Mvc;
using PortalCliente.API.Attibutes;

namespace PortalCliente.API.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet("")]
        //[ApiKey]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
