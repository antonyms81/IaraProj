using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IaraProj.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class criacadebase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cotacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CnpjComprador = table.Column<string>(type: "varchar(14)", nullable: false),
                    CNPJFornecedor = table.Column<string>(type: "varchar(14)", nullable: false),
                    NumeroCotacao = table.Column<int>(type: "int", nullable: false),
                    DataCotacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataEntregaCotacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    CEP = table.Column<string>(type: "varchar(14)", nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(50)", nullable: true),
                    Complemento = table.Column<string>(type: "varchar(50)", nullable: true),
                    Bairro = table.Column<string>(type: "varchar(50)", nullable: true),
                    UF = table.Column<string>(type: "varchar(5)", nullable: true),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cotacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CotacaoItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(500)", nullable: false),
                    NumeroItem = table.Column<int>(type: "int", nullable: false),
                    Preco = table.Column<double>(type: "float", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Marca = table.Column<string>(type: "varchar(50)", nullable: false),
                    Unidade = table.Column<string>(type: "varchar(50)", nullable: false),
                    IdCotacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CotacaoItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CotacaoItem_Cotacao_IdCotacao",
                        column: x => x.IdCotacao,
                        principalTable: "Cotacao",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CotacaoItem_IdCotacao",
                table: "CotacaoItem",
                column: "IdCotacao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CotacaoItem");

            migrationBuilder.DropTable(
                name: "Cotacao");
        }
    }
}
