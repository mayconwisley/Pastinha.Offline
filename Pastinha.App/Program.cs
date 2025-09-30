using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pastinha.App.OpenFolder;
using Pastinha.App.ReadFileWhatcher;
using Pastinha.App.ReadPathFolder;
using Pastinha.App.UpMigration;
using Pastinha.Base.Database;
using Pastinha.Base.Repository;
using Pastinha.Base.Repository.Interface;
using Pastinha.Utility.Constant;
using Pastinha.Utility.Utility;

namespace Pastinha.App;

internal static class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        try
        {
            ApplicationConfiguration.Initialize();
            ServiceProvider serviceProvider = SettingsService(args)!;
            FrmMain frmMain = serviceProvider!.GetRequiredService<FrmMain>();
            Application.Run(frmMain);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Erro");
        }
    }

    static ServiceProvider? SettingsService(string[] args)
    {

        var pastinhaDb = Environment.GetEnvironmentVariable(Constants.PASTINHA_BD, EnvironmentVariableTarget.Machine);

        if (!File.Exists(pastinhaDb) && !string.IsNullOrEmpty(pastinhaDb))
        {
            MessageBox.Show($"Arquivo/Local não esta definido na variável de ambiente!\n" +
                            $"Exclua a váriavel '{Constants.PASTINHA_BD}' e abra o sistema como administrador.", "Aviso");
            Application.ExitThread();
            return null;
        }

        if (string.IsNullOrEmpty(pastinhaDb))
        {
            FrmConfigurationBbAndVariables frmConfigurationBbAndVariables = new();
            frmConfigurationBbAndVariables.ShowDialog();
        }

        UpdateMigration.MigrationDataBase();

        var connectionString = PastinhaStringConnection.ConnectionString();
        var serviceProvider = new ServiceCollection()
            .AddHttpClient()
            .AddMemoryCache()
            .AddDbContextPool<PastinhaContext>(op => op.UseSqlite(connectionString))
            .AddSingleton<FrmMain>()
            .AddSingleton<FrmFolder>()
            .AddSingleton<FrmConfigurationBbAndVariables>()
            .AddSingleton<FrmViewReport>()
            .AddSingleton<FrmGenerateReport>()
            .AddSingleton<FrmOffline>()
            .AddSingleton<FrmStatusFired>()
            .AddSingleton<FrmFromTo>()
            .AddSingleton<CreateLog>()
            .AddSingleton(args)

            .AddScoped<PastinhaContext>()

            .AddScoped<IFolderPastinhaRepository, FolderPastinhaRepository>()
            .AddScoped<IFolderOfflineRepository, FolderOfflineRepository>()
            .AddScoped<ICountDataFileRepository, CountDataFileRepository>()
            .AddScoped<IStatusFiredRepository, StatusFiredRepository>()
            .AddScoped<IEmployeeRepository, EmployeeRepository>()
            .AddScoped<IFileProcessedRepository, FileProcessedRepository>()
            .AddScoped<IFromToCompanyRepository, FromToCompanyRepository>()
            .AddScoped<IFromToTypeRepository, FromToTypeRepository>()
            .AddScoped<IFromToEmployeeRepository, FromToEmployeeRepository>()
            .AddScoped<Folder>()
            .AddScoped<ReadFile>()
            .AddScoped<ReadPath>()
            .BuildServiceProvider();

        return serviceProvider;
    }
}