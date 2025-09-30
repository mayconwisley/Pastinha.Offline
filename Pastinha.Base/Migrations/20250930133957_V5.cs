using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Pastinha.Base.Migrations;

/// <inheritdoc />
public partial class V5 : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Authentication");

        migrationBuilder.DropTable(
            name: "AuthenticationWithKey");

        migrationBuilder.DropTable(
            name: "BaseUrls");

        migrationBuilder.DropTable(
            name: "EndpointsPastinha");

        migrationBuilder.DropTable(
            name: "FolderListPageables");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Authentication",
            columns: table => new
            {
                Id = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                Password = table.Column<string>(type: "TEXT", nullable: false),
                Username = table.Column<string>(type: "TEXT", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Authentication", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "AuthenticationWithKey",
            columns: table => new
            {
                Id = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                AccessKey = table.Column<string>(type: "TEXT", nullable: false),
                Scope = table.Column<string>(type: "TEXT", nullable: true),
                Secret = table.Column<string>(type: "TEXT", nullable: false),
                TenantName = table.Column<string>(type: "TEXT", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AuthenticationWithKey", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "BaseUrls",
            columns: table => new
            {
                Id = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                Name = table.Column<string>(type: "TEXT", nullable: false),
                UrlBase = table.Column<string>(type: "TEXT", nullable: false),
                UrlDevSenior = table.Column<string>(type: "TEXT", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_BaseUrls", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "EndpointsPastinha",
            columns: table => new
            {
                Id = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                Endpoint = table.Column<string>(type: "TEXT", nullable: false),
                Name = table.Column<string>(type: "TEXT", nullable: false),
                Type = table.Column<string>(type: "TEXT", nullable: false),
                UrlDevSenior = table.Column<string>(type: "TEXT", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_EndpointsPastinha", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "FolderListPageables",
            columns: table => new
            {
                Id = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                AllFolder = table.Column<bool>(type: "INTEGER", nullable: false),
                Author = table.Column<string>(type: "TEXT", nullable: false),
                IdFolder = table.Column<string>(type: "TEXT", nullable: false),
                Title = table.Column<string>(type: "TEXT", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_FolderListPageables", x => x.Id);
            });

        migrationBuilder.InsertData(
            table: "BaseUrls",
            columns: new[] { "Id", "Name", "UrlBase", "UrlDevSenior" },
            values: new object[] { 1, "Base Url", "https://platform.senior.com.br/t/senior.com.br/bridge/1.0/rest/platform", "https://dev.senior.com.br/apis_privadas/" });

        migrationBuilder.InsertData(
            table: "EndpointsPastinha",
            columns: new[] { "Id", "Endpoint", "Name", "Type", "UrlDevSenior" },
            values: new object[,]
            {
                { 1, "/authentication/actions/login", "Login", "Publico", "https://dev.senior.com.br/api_privada/platform_authentication/" },
                { 2, "/authentication/actions/loginWithKey", "LoginWithKey", "Publico", "https://dev.senior.com.br/api_privada/platform_authentication/" },
                { 3, "/ecm_ged/entities/draftDocument", "DraftDocument", "Privado", "https://dev.senior.com.br/api_privada/platform_ecm_ged/" },
                { 4, "/ecm_ged/entities/document", "Document", "Privado", "https://dev.senior.com.br/api_privada/platform_ecm_ged/" },
                { 5, "/ecm_ged/actions/approveDocumentVersion", "ApproveDocumentVersion", "Publico", "https://dev.senior.com.br/api_privada/platform_ecm_ged/" },
                { 6, "/ecm_ged/queries/searchDocument", "SearchDocument", "Publico", "https://dev.senior.com.br/api_privada/platform_ecm_ged/" },
                { 7, "/ecm_ged/queries/folderListPageable", "FolderListPageable", "Privado", "https://dev.senior.com.br/api_privada/platform_ecm_ged/" },
                { 8, "/ecm_ged/queries/searchDocumentByProperties", "SearchDocumentByProperties", "Publico", "https://dev.senior.com.br/api_privada/platform_ecm_ged/" },
                { 9, "/ecm_ged/actions/moveDocumentBulk", "MoveDocumentBulk", "Publico", "https://dev.senior.com.br/api_privada/platform_ecm_ged/" },
                { 10, "/ecm_ged/actions/moveDocument", "MoveDocument", "Publico", "https://dev.senior.com.br/api_privada/platform_ecm_ged/" },
                { 11, "/ecm_ged/entities/folder", "Folder", "Privado", "https://dev.senior.com.br/api_privada/platform_ecm_ged/" }
            });
    }
}
