using Microsoft.EntityFrameworkCore;
using Pastinha.Base.Database;
using Pastinha.Base.Repository;
using Pastinha.Base.Repository.Interface;
using Pastinha.Service;
using Pastinha.Service.Service.Database;
using Pastinha.Service.Service.Database.Interface;
using Pastinha.Service.Service.Process;
using Pastinha.Service.Service.Process.Interface;
using Pastinha.Utility.Utility;
using System.Text;
using System.Text.Json;

var jsonOption = new JsonSerializerOptions
{
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    WriteIndented = true
};

Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
var connectionString = PastinhaStringConnection.ConnectionString();

var host = Host.CreateDefaultBuilder(args)
    .UseWindowsService()
    .ConfigureServices(services =>
    {
        services.AddHttpClient();
        services.AddDbContextPool<PastinhaContext>(op =>
            op.UseSqlite(connectionString, sqliteOptionsAction =>
            {
                sqliteOptionsAction.CommandTimeout(30); // Timeout adequado
            }
        ));
        services.AddHostedService<Worker>();
        services.AddMemoryCache();
        services.AddSingleton(jsonOption);
        services.AddSingleton<CreateLog>();
        services.AddSingleton<IProcessQrCodeImage, ProcessQrCodeImage>();
        services.AddSingleton<IProcessEnhanceImageForQrCode, ProcessEnhanceImageForQrCode>();
        services.AddSingleton<IProcessSaveImageEnhance, ProcessSaveImageEnhance>();
        services.AddSingleton<IProcessFile, ProcessFile>();
        services.AddSingleton<IProcessFilePdf, ProcessFilePdf>();
        services.AddSingleton<IProcessFileImage, ProcessFileImage>();
        services.AddSingleton<IProcessFileExtension, ProcessFileExtension>();
        services.AddSingleton<IProcessOffline, ProcessOffline>();
        services.AddSingleton<IRenameFile, RenameFile>();
        services.AddSingleton<ICreateFolder, CreateFolder>();
        services.AddSingleton<IMoveFolder, MoveFolder>();
        services.AddSingleton<IMoveFoderError, MoveFoderError>();
        services.AddSingleton<ICreateFolderLoose, CreateFolderLoose>();
        services.AddSingleton<IOrganizeFile, OrganizeFile>();
        services.AddSingleton<ICountFile, CountFile>();
        services.AddSingleton<IImageToPdf, ImageToPdf>();
        services.AddSingleton<IReturnPathPastinha, ReturnPathPastinha>();
        services.AddSingleton<IDeleteFolder, DeleteFolder>();
        services.AddSingleton<IResizeImage, ResizeImage>();
        services.AddSingleton<ICreateUpdateEmployee, CreateUpdateEmployee>();
        services.AddSingleton<ICreateUpdateFileProcessed, CreateUpdateFileProcessed>();
        services.AddSingleton<IReturnFromTo, ReturnFromTo>();

        services.AddScoped<IReturnFolderOfflineService, ReturnFolderOfflineService>();
        services.AddScoped<IReturnStatusFired, ReturnStatusFired>();
        services.AddScoped<IUpdateCountDataFile, UpdateCountDataFile>();
        services.AddScoped<IReturnCountDataFile, ReturnCountDataFile>();
        services.AddScoped<IFolderPastinhaRepository, FolderPastinhaRepository>();
        services.AddScoped<IFolderOfflineRepository, FolderOfflineRepository>();
        services.AddScoped<ICountDataFileRepository, CountDataFileRepository>();
        services.AddScoped<IStatusFiredRepository, StatusFiredRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IFileProcessedRepository, FileProcessedRepository>();
        services.AddScoped<IFromToCompanyRepository, FromToCompanyRepository>();
        services.AddScoped<IFromToTypeRepository, FromToTypeRepository>();
        services.AddScoped<IFromToEmployeeRepository, FromToEmployeeRepository>();
    })
    .Build();
host.Run();
