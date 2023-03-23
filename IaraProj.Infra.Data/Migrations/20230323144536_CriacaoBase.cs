using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IaraProj.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cotacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CnpjComprador = table.Column<string>(type: "varchar(14)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cotacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CotacaoItens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCotacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CotacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CotacaoItens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CotacaoItens_Cotacao_CotacaoId",
                        column: x => x.CotacaoId,
                        principalTable: "Cotacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CotacaoItens_CotacaoId",
                table: "CotacaoItens",
                column: "CotacaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CotacaoItens");

            migrationBuilder.DropTable(
                name: "Cotacao");
        }
    }
}
