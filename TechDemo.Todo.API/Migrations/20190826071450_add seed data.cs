using Microsoft.EntityFrameworkCore.Migrations;

namespace TechDemo.Todo.API.Migrations
{
    public partial class addseeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TodoItems",
                columns: new[] { "Id", "Description", "Lat", "Long", "Title" },
                values: new object[] { 1, "test desc", -121.23126000000001, 42.6235675, "test title" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
