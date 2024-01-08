using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalCliente.API.Models;

namespace PortalCliente.API.Data.Mappings
{
    public class CidadeMap : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            // Tabela
            builder.ToTable("TAB_Cidades");

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

        }
    }
}
