using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Pastinha.Base.Migrations;

/// <inheritdoc />
public partial class V1 : Migration
{
	/// <inheritdoc />
	protected override void Up(MigrationBuilder migrationBuilder)
	{
		migrationBuilder.CreateTable(
			name: "Authentication",
			columns: table => new
			{
				Id = table.Column<int>(type: "INTEGER", nullable: false)
					.Annotation("Sqlite:Autoincrement", true),
				Username = table.Column<string>(type: "TEXT", nullable: false),
				Password = table.Column<string>(type: "TEXT", nullable: false)
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
				Secret = table.Column<string>(type: "TEXT", nullable: false),
				TenantName = table.Column<string>(type: "TEXT", nullable: false),
				Scope = table.Column<string>(type: "TEXT", nullable: true)
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
			name: "CountDataFiles",
			columns: table => new
			{
				Id = table.Column<int>(type: "INTEGER", nullable: false)
					.Annotation("Sqlite:Autoincrement", true),
				DateProcess = table.Column<DateTime>(type: "TEXT", nullable: false),
				CountPDF = table.Column<int>(type: "INTEGER", nullable: false),
				CountImage = table.Column<int>(type: "INTEGER", nullable: false),
				CountOtherFormat = table.Column<int>(type: "INTEGER", nullable: false),
				CountSendPlatform = table.Column<int>(type: "INTEGER", nullable: false)
			},
			constraints: table =>
			{
				table.PrimaryKey("PK_CountDataFiles", x => x.Id);
			});

		migrationBuilder.CreateTable(
			name: "Employees",
			columns: table => new
			{
				Id = table.Column<int>(type: "INTEGER", nullable: false)
					.Annotation("Sqlite:Autoincrement", true),
				NumEmp = table.Column<int>(type: "INTEGER", nullable: false),
				TipCol = table.Column<int>(type: "INTEGER", nullable: false),
				NumCad = table.Column<int>(type: "INTEGER", nullable: false),
				SitAfa = table.Column<int>(type: "INTEGER", nullable: false),
				NomFun = table.Column<string>(type: "TEXT", nullable: true)
			},
			constraints: table =>
			{
				table.PrimaryKey("PK_Employees", x => x.Id);
			});

		migrationBuilder.CreateTable(
			name: "EndpointsPastinha",
			columns: table => new
			{
				Id = table.Column<int>(type: "INTEGER", nullable: false)
					.Annotation("Sqlite:Autoincrement", true),
				Name = table.Column<string>(type: "TEXT", nullable: false),
				Endpoint = table.Column<string>(type: "TEXT", nullable: false),
				Type = table.Column<string>(type: "TEXT", nullable: false),
				UrlDevSenior = table.Column<string>(type: "TEXT", nullable: false)
			},
			constraints: table =>
			{
				table.PrimaryKey("PK_EndpointsPastinha", x => x.Id);
			});

		migrationBuilder.CreateTable(
			name: "FileProcesseds",
			columns: table => new
			{
				Id = table.Column<int>(type: "INTEGER", nullable: false)
					.Annotation("Sqlite:Autoincrement", true),
				NumEmp = table.Column<int>(type: "INTEGER", nullable: false),
				TipCol = table.Column<int>(type: "INTEGER", nullable: false),
				NumCad = table.Column<int>(type: "INTEGER", nullable: false),
				AmountProcessed = table.Column<int>(type: "INTEGER", nullable: false),
				NomDoc = table.Column<string>(type: "TEXT", nullable: false),
				DateProcessed = table.Column<DateOnly>(type: "TEXT", nullable: false)
			},
			constraints: table =>
			{
				table.PrimaryKey("PK_FileProcesseds", x => x.Id);
			});

		migrationBuilder.CreateTable(
			name: "FolderListPageables",
			columns: table => new
			{
				Id = table.Column<int>(type: "INTEGER", nullable: false)
					.Annotation("Sqlite:Autoincrement", true),
				IdFolder = table.Column<string>(type: "TEXT", nullable: false),
				Author = table.Column<string>(type: "TEXT", nullable: false),
				Title = table.Column<string>(type: "TEXT", nullable: false),
				AllFolder = table.Column<bool>(type: "INTEGER", nullable: false)
			},
			constraints: table =>
			{
				table.PrimaryKey("PK_FolderListPageables", x => x.Id);
			});

		migrationBuilder.CreateTable(
			name: "FoldersOffline",
			columns: table => new
			{
				Id = table.Column<int>(type: "INTEGER", nullable: false)
					.Annotation("Sqlite:Autoincrement", true),
				IsOffline = table.Column<bool>(type: "INTEGER", nullable: false),
				PathOffline = table.Column<string>(type: "TEXT", nullable: false)
			},
			constraints: table =>
			{
				table.PrimaryKey("PK_FoldersOffline", x => x.Id);
			});

		migrationBuilder.CreateTable(
			name: "FoldersPastinha",
			columns: table => new
			{
				Id = table.Column<int>(type: "INTEGER", nullable: false)
					.Annotation("Sqlite:Autoincrement", true),
				PathInput = table.Column<string>(type: "TEXT", nullable: false),
				PathOutput = table.Column<string>(type: "TEXT", nullable: false),
				PathError = table.Column<string>(type: "TEXT", nullable: false),
				PathLog = table.Column<string>(type: "TEXT", nullable: false),
				IsDelete = table.Column<bool>(type: "INTEGER", nullable: false),
				DaysDelete = table.Column<int>(type: "INTEGER", nullable: false)
			},
			constraints: table =>
			{
				table.PrimaryKey("PK_FoldersPastinha", x => x.Id);
			});

		migrationBuilder.CreateTable(
			name: "StatusFireds",
			columns: table => new
			{
				Id = table.Column<int>(type: "INTEGER", nullable: false)
					.Annotation("Sqlite:Autoincrement", true),
				CodeStatus = table.Column<int>(type: "INTEGER", nullable: false),
				Description = table.Column<string>(type: "TEXT", nullable: false)
			},
			constraints: table =>
			{
				table.PrimaryKey("PK_StatusFireds", x => x.Id);
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

		migrationBuilder.CreateIndex(
			name: "IX_CountDataFiles_DateProcess",
			table: "CountDataFiles",
			column: "DateProcess",
			descending: new bool[0]);

		migrationBuilder.CreateIndex(
			name: "IX_Employees_NumEmp_TipCol_NumCad",
			table: "Employees",
			columns: new[] { "NumEmp", "TipCol", "NumCad" },
			unique: true);

		migrationBuilder.CreateIndex(
			name: "IX_FileProcesseds_NumEmp_TipCol_NumCad_NomDoc_DateProcessed",
			table: "FileProcesseds",
			columns: new[] { "NumEmp", "TipCol", "NumCad", "NomDoc", "DateProcessed" },
			unique: true);
	}

	/// <inheritdoc />
	protected override void Down(MigrationBuilder migrationBuilder)
	{
		migrationBuilder.DropTable(
			name: "Authentication");

		migrationBuilder.DropTable(
			name: "AuthenticationWithKey");

		migrationBuilder.DropTable(
			name: "BaseUrls");

		migrationBuilder.DropTable(
			name: "CountDataFiles");

		migrationBuilder.DropTable(
			name: "Employees");

		migrationBuilder.DropTable(
			name: "EndpointsPastinha");

		migrationBuilder.DropTable(
			name: "FileProcesseds");

		migrationBuilder.DropTable(
			name: "FolderListPageables");

		migrationBuilder.DropTable(
			name: "FoldersOffline");

		migrationBuilder.DropTable(
			name: "FoldersPastinha");

		migrationBuilder.DropTable(
			name: "StatusFireds");
	}
}
