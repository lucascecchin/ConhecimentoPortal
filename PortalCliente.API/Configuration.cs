using Microsoft.AspNetCore.Mvc;
using PortalCliente.API.Attibutes;

namespace PortalCliente.API
{
    public static class Configuration
    {
        //TOKEN - JWT - Json Web Token
        public static string JwtKey = "ZmVkYWY3ZDg4NjNiNDhlMTk3YjkyODdkNDkyYjcwOGU=";


        //É possível criar tokens genericos, fazendo isso é só colocar o atributo [ApiKey], na classe ou metodo do controller
        //A classe ApiKeyAttribute é a responsavel por fazer esse controle.
        //Exemplo:
        //  [ApiKey]
        //  public IActionResult Get()
        //  {
        //        return Ok();
        //  }
        public static string ApiKeyName = "api_key";
        public static string ApiKey = "curso_Api";

        public static SmtpConfiguration Smtp = new();

        public class SmtpConfiguration
        {
            public string Host { get; set; }
            public int Port { get; set; } = 25;
            public string UserName { get; set; }
            public string Password { get; set; }
        }
    }
}
