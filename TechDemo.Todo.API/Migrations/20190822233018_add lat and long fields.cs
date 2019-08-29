using Microsoft.EntityFrameworkCore.Migrations;

namespace TechDemo.Todo.API.Migrations
{
    public partial class addlatandlongfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Lat",
                table: "TodoItems",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Long",
                table: "TodoItems",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lat",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "Long",
                table: "TodoItems");
        }
    }
}
