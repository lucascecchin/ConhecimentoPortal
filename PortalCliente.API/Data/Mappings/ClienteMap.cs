using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalCliente.API.Models;

namespace PortalCliente.API.Data.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            // Tabela
            builder.ToTable("TAB_Clientes");

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
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100);

            builder.Property(x => x.Email);

            // Relacionamentos
            builder.HasOne(x => x.Cidade)
                .WithMany(x => x.Cliente)
                .HasConstraintName("FK_TAB_Clientes_TAB_Cidades")
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
