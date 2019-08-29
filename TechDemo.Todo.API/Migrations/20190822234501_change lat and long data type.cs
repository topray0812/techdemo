using Microsoft.EntityFrameworkCore.Migrations;

namespace TechDemo.Todo.API.Migrations
{
    public partial class changelatandlongdatatype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Long",
                table: "TodoItems",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<double>(
                name: "Lat",
                table: "TodoItems",
                nullable: false,
                oldClrType: typeof(float));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Long",
                table: "TodoItems",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<float>(
                name: "Lat",
                table: "TodoItems",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
