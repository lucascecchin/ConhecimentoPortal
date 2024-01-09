using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PortalCliente.API;
using PortalCliente.API.Data;
using PortalCliente.API.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services
    .AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });

builder.Services.AddTransient<TokenService>();
//builder.Services.AddTransient(); //Sempre cria um novo, em cada metodo cria um novo
//builder.Services.AddScoped(); //É por requisião, então enquanto a requisição durar ele é valido, passando de metodo para método
//builder.Services.AddSingleton(); //É um por APP, sempre que sobe a aplicação ele fica valido até que a aplicação sempre seja carregada novamente

ConfigureServices(builder);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Sempre tem que ser nessa ordem, primeiro falar quem é para depois saber oque pode fazer..
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

void ConfigureServices(WebApplicationBuilder builder)
{
    //var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    //builder.Services.AddDbContext<DataContext>(
    //    options =>
    //        options.UseSqlServer(connectionString));

    builder.Services.AddDbContext<DataContext>();
}