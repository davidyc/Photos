using Microsoft.EntityFrameworkCore.Migrations;

namespace Photos.Infrastructure.Migrations
{
    public partial class RemoveTestAutoMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Events");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
