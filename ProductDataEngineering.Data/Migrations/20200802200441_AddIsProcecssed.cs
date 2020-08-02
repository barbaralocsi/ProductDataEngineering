using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductDataEngineering.Data.Migrations
{
    public partial class AddIsProcecssed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsProcessed",
                table: "Numbers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsProcessed",
                table: "Numbers");
        }
    }
}
