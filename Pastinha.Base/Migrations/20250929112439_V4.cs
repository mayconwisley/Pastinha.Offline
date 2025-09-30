using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pastinha.Base.Migrations;

/// <inheritdoc />
public partial class V4 : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "FromToEmployees",
            columns: table => new
            {
                Id = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                FromEmployee = table.Column<int>(type: "INTEGER", nullable: false),
                ToEmployee = table.Column<int>(type: "INTEGER", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_FromToEmployees", x => x.Id);
            });

        migrationBuilder.CreateIndex(
            name: "IX_FromToEmployees_FromEmployee_ToEmployee",
            table: "FromToEmployees",
            columns: new[] { "FromEmployee", "ToEmployee" },
            unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "FromToEmployees");
    }
}
