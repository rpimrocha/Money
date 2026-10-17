using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Money.Api.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cupons",
                columns: table => new
                {
                    Codigo = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<string>(type: "CHAR(8)", maxLength: 8, nullable: false),
                    Titulo = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: true),
                    EstaAtivo = table.Column<bool>(type: "BIT", nullable: false),
                    Valor = table.Column<decimal>(type: "MONEY", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cupons", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Codigo = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Referencia = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    Titulo = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: true),
                    EstaAtivo = table.Column<bool>(type: "BIT", nullable: false),
                    Valor = table.Column<decimal>(type: "MONEY", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Codigo = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<string>(type: "CHAR(8)", maxLength: 8, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    ReferenciaPortalPagamento = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: true),
                    PortalPagamento = table.Column<short>(type: "SMALLINT", nullable: false),
                    SituacaoPedido = table.Column<short>(type: "SMALLINT", nullable: false),
                    CodigoProduto = table.Column<long>(type: "BIGINT", nullable: false),
                    CodigoCupom = table.Column<long>(type: "BIGINT", nullable: true),
                    CodigoUsuario = table.Column<string>(type: "VARCHAR(160)", maxLength: 160, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Pedidos_Cupons_CodigoCupom",
                        column: x => x.CodigoCupom,
                        principalTable: "Cupons",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pedidos_Produtos_CodigoProduto",
                        column: x => x.CodigoProduto,
                        principalTable: "Produtos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_CodigoCupom",
                table: "Pedidos",
                column: "CodigoCupom");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_CodigoProduto",
                table: "Pedidos",
                column: "CodigoProduto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Cupons");

            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
