using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PortalCliente.API.Data.Mappings;
using PortalCliente.API.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace PortalCliente.API.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=localhost;Database=PortalCliente;User ID=sa;Password=15974;TrustServerCertificate=True");


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CidadeMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());

        }
    }
}
