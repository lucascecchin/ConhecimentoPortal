using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalCliente.API.Migrations
{
    /// <inheritdoc />
    public partial class AjusteNomeColuna : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CidadeCod",
                table: "TAB_Clientes",
                newName: "CodCidades");

            migrationBuilder.RenameIndex(
                name: "IX_TAB_Clientes_CidadeCod",
                table: "TAB_Clientes",
                newName: "IX_TAB_Clientes_CodCidades");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CodCidades",
                table: "TAB_Clientes",
                newName: "CidadeCod");

            migrationBuilder.RenameIndex(
                name: "IX_TAB_Clientes_CodCidades",
                table: "TAB_Clientes",
                newName: "IX_TAB_Clientes_CidadeCod");
        }
    }
}
