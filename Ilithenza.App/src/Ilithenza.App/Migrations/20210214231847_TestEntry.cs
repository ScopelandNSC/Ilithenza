using Microsoft.EntityFrameworkCore.Migrations;

namespace Ilithenza.App.Migrations
{
    public partial class TestEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "ClassId", "Description", "Name" },
                values: new object[] { 1, "Can manipulate Earth, water, fire, air", "Elementalist" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Class",
                keyColumn: "ClassId",
                keyValue: 1);
        }
    }
}
