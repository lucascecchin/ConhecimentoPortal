using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PortalCliente.API.Models;

namespace PortalCliente.API.Data.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            // Tabela
            builder.ToTable("TAB_Usuarios");

            // Chave Primária
            builder.HasKey(x => x.Cod);

            // Identity
            builder.Property(x => x.Cod)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            // Propriedades
            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("VARCHAR")
                .HasMaxLength(100);

            builder.Property(x => x.Sobrenome)
                .IsRequired()
                .HasColumnName("Sobrenome")
                .HasColumnType("VARCHAR")
                .HasMaxLength(100);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("VARCHAR")
                .HasMaxLength(100);

            builder.Property(x => x.Senha)
                .IsRequired()
                .HasColumnName("Senha")
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

        }
    }
}
