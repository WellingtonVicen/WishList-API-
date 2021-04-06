using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "VARCHAR(255)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: true),
                    Link = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    Foto = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    GanhouComprou = table.Column<bool>(name: "Ganhou/Comprou", type: "TINYINT(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item");
        }
    }
}
