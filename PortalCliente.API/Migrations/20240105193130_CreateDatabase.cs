using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalCliente.API.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TAB_Cidades",
                columns: table => new
                {
                    Cod = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAB_Cidades", x => x.Cod);
                });

            migrationBuilder.CreateTable(
                name: "TAB_Clientes",
                columns: table => new
                {
                    Cod = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CidadeCod = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAB_Clientes", x => x.Cod);
                    table.ForeignKey(
                        name: "FK_TAB_Clientes_TAB_Cidades",
                        column: x => x.CidadeCod,
                        principalTable: "TAB_Cidades",
                        principalColumn: "Cod");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TAB_Clientes_CidadeCod",
                table: "TAB_Clientes",
                column: "CidadeCod");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TAB_Clientes");

            migrationBuilder.DropTable(
                name: "TAB_Cidades");
        }
    }
}
