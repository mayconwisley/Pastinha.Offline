using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pastinha.Base.Migrations;

/// <inheritdoc />
public partial class V3 : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "FromToTypes",
            columns: table => new
            {
                Id = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                FromType = table.Column<int>(type: "INTEGER", nullable: false),
                ToType = table.Column<int>(type: "INTEGER", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_FromToTypes", x => x.Id);
            });

        migrationBuilder.CreateIndex(
            name: "IX_FromToTypes_FromType_ToType",
            table: "FromToTypes",
            columns: new[] { "FromType", "ToType" },
            unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "FromToTypes");
    }
}
