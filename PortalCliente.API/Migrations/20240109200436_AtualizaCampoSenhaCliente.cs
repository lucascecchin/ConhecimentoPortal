using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalCliente.API.Migrations
{
    /// <inheritdoc />
    public partial class AtualizaCampoSenhaCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "TAB_Usuarios",
                type: "VARCHAR(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(40)",
                oldMaxLength: 40);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "TAB_Usuarios",
                type: "VARCHAR(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(255)",
                oldMaxLength: 255);
        }
    }
}
