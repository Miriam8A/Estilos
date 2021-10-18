using Microsoft.EntityFrameworkCore.Migrations;

namespace Estilos.Data.Migrations
{
    public partial class Image2Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "image",
                table: "t_product2",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image",
                table: "t_product2");
        }
    }
}
