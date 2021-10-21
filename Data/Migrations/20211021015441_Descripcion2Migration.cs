using Microsoft.EntityFrameworkCore.Migrations;

namespace Estilos.Data.Migrations
{
    public partial class Descripcion2Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "descripcion",
                table: "t_product2",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "descripcion",
                table: "t_product2");
        }
    }
}
