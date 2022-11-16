using Microsoft.EntityFrameworkCore.Migrations;

namespace LocacaoImoveis.Infrastructure.Migrations
{
    public partial class imageSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CaminhoImagem",
                table: "IMAGEM",
                type: "varchar(300)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CaminhoImagem",
                table: "IMAGEM",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(300)");
        }
    }
}
