using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class apiMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompraProdutos");

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Enderecos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Compras",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "CompraProduto",
                columns: table => new
                {
                    ComprasCompraId = table.Column<int>(type: "int", nullable: false),
                    ProdutosProdutoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompraProduto", x => new { x.ComprasCompraId, x.ProdutosProdutoId });
                    table.ForeignKey(
                        name: "FK_CompraProduto_Compras_ComprasCompraId",
                        column: x => x.ComprasCompraId,
                        principalTable: "Compras",
                        principalColumn: "CompraId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompraProduto_Produtos_ProdutosProdutoId",
                        column: x => x.ProdutosProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompraProduto_ProdutosProdutoId",
                table: "CompraProduto",
                column: "ProdutosProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompraProduto");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Compras");

            migrationBuilder.CreateTable(
                name: "CompraProdutos",
                columns: table => new
                {
                    CompraProdutoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompraId = table.Column<int>(type: "int", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompraProdutos", x => x.CompraProdutoId);
                    table.ForeignKey(
                        name: "FK_CompraProdutos_Compras_CompraId",
                        column: x => x.CompraId,
                        principalTable: "Compras",
                        principalColumn: "CompraId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompraProdutos_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompraProdutos_CompraId",
                table: "CompraProdutos",
                column: "CompraId");

            migrationBuilder.CreateIndex(
                name: "IX_CompraProdutos_ProdutoId",
                table: "CompraProdutos",
                column: "ProdutoId");
        }
    }
}
