using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pastinha.Base.Migrations;

/// <inheritdoc />
public partial class V2 : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "FromToCompanies",
            columns: table => new
            {
                Id = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                FromCompany = table.Column<int>(type: "INTEGER", nullable: false),
                ToCompany = table.Column<int>(type: "INTEGER", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_FromToCompanies", x => x.Id);
            });

        migrationBuilder.CreateIndex(
            name: "IX_FromToCompanies_FromCompany_ToCompany",
            table: "FromToCompanies",
            columns: new[] { "FromCompany", "ToCompany" },
            unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "FromToCompanies");
    }
}
