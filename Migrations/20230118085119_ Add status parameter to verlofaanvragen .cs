using Microsoft.EntityFrameworkCore.Migrations;

namespace GeoProfs.Migrations
{
    public partial class Addstatusparametertoverlofaanvragen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "Verlofaanvraag",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "Verlofaanvraag");
        }
    }
}
