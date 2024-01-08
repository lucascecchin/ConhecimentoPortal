﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PortalCliente.API.Data;

#nullable disable

namespace PortalCliente.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240105193130_CreateDatabase")]
    partial class CreateDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PortalCliente.API.Models.Cidade", b =>
                {
                    b.Property<int>("Cod")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Cod"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Nome");

                    b.HasKey("Cod");

                    b.ToTable("TAB_Cidades", (string)null);
                });

            modelBuilder.Entity("PortalCliente.API.Models.Cliente", b =>
                {
                    b.Property<int>("Cod")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Cod"));

                    b.Property<int>("CidadeCod")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Nome");

                    b.HasKey("Cod");

                    b.HasIndex("CidadeCod");

                    b.ToTable("TAB_Clientes", (string)null);
                });

            modelBuilder.Entity("PortalCliente.API.Models.Cliente", b =>
                {
                    b.HasOne("PortalCliente.API.Models.Cidade", "Cidade")
                        .WithMany("Cliente")
                        .HasForeignKey("CidadeCod")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_TAB_Clientes_TAB_Cidades");

                    b.Navigation("Cidade");
                });

            modelBuilder.Entity("PortalCliente.API.Models.Cidade", b =>
                {
                    b.Navigation("Cliente");
                });
#pragma warning restore 612, 618
        }
    }
}