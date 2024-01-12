using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalCliente.API.Migrations
{
    /// <inheritdoc />
    public partial class CreateCampoImagem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Imagem",
                table: "TAB_Usuarios",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "TAB_Usuarios");
        }
    }
}
