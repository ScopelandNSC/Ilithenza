using Microsoft.EntityFrameworkCore.Migrations;

namespace Ilithenza.App.Migrations
{
    public partial class MyBaseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.ClassId);
                });

            migrationBuilder.CreateTable(
                name: "ClassPath",
                columns: table => new
                {
                    PathId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassPath", x => x.PathId);
                });

            migrationBuilder.CreateTable(
                name: "ClassPathNode",
                columns: table => new
                {
                    NodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DetailedDescription = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Tier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Ap = table.Column<int>(type: "int", nullable: true),
                    RecoveryTime = table.Column<int>(type: "int", nullable: true),
                    DependsOnId = table.Column<int>(type: "int", nullable: true),
                    RelatedAttributeId = table.Column<int>(type: "int", nullable: true),
                    Roll = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PathId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassPathNode", x => x.NodeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "ClassPath");

            migrationBuilder.DropTable(
                name: "ClassPathNode");
        }
    }
}
