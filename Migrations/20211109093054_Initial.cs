using Microsoft.EntityFrameworkCore.Migrations;

namespace mobile.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Catalogs",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    marca = table.Column<string>(type: "TEXT", nullable: true),
                    nume = table.Column<string>(type: "TEXT", nullable: true),
                    prenume = table.Column<string>(type: "TEXT", nullable: true),
                    nota1 = table.Column<decimal>(type: "TEXT", nullable: false),
                    nota2 = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogs", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Catalogs");
        }
    }
}
