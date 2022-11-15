using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocacaoImoveis.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IMOVEL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipoImovel = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VagasGaragem = table.Column<int>(type: "int", nullable: false),
                    DataAnuncio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NomProprietario = table.Column<string>(type: "varchar(200)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IMOVEL", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ENDERECO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logradouro = table.Column<string>(type: "varchar(200)", nullable: false),
                    Numero = table.Column<string>(type: "varchar(50)", nullable: false),
                    Complemento = table.Column<string>(type: "varchar(250)", nullable: false),
                    Cep = table.Column<string>(type: "varchar(8)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(100)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(50)", nullable: false),
                    ImovelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENDERECO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ENDERECO_IMOVEL_ImovelId",
                        column: x => x.ImovelId,
                        principalTable: "IMOVEL",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IMAGEM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaminhoImagem = table.Column<string>(type: "varchar(100)", nullable: false),
                    ImovelId = table.Column<int>(type: "int", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IMAGEM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IMAGEM_IMOVEL_ImovelId",
                        column: x => x.ImovelId,
                        principalTable: "IMOVEL",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ENDERECO_ImovelId",
                table: "ENDERECO",
                column: "ImovelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IMAGEM_ImovelId",
                table: "IMAGEM",
                column: "ImovelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ENDERECO");

            migrationBuilder.DropTable(
                name: "IMAGEM");

            migrationBuilder.DropTable(
                name: "IMOVEL");
        }
    }
}
