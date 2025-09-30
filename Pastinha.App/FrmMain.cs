using Microsoft.Extensions.DependencyInjection;
using Pastinha.App.OpenFolder;
using Pastinha.App.ReadPathFolder;
using Pastinha.App.RestartAdmin;
using Pastinha.Base.Repository.Interface;
using Pastinha.Utility.Constant;
using Pastinha.Utility.Service;
using Pastinha.Utility.Utility;
using System.ComponentModel;
using System.Reflection;

namespace Pastinha.App;

public partial class FrmMain : Form
{
    readonly IServiceProvider _serviceProvider;
    readonly Folder _folder;
    readonly ReadPath _readPath;
    readonly string[] _args;

    public FrmMain(IServiceProvider serviceProvider, Folder folder, ReadPath readPath, string[] args)
    {
        InitializeComponent();
        _serviceProvider = serviceProvider;
        _folder = folder;
        _readPath = readPath;
        _args = args;

        var version = Assembly.GetExecutingAssembly()
                              .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?
                              .InformationalVersion?
                              .Split('+')[0];
        this.Text = "Pastinha.Exe - Offline";
        ToolLblInfo.Text = $"Desenvolvido por Maycon Wisley - Versão {version}";
    }

    private bool isTimerStop = false;
    private async Task InfoServicesAsync()
    {
        try
        {
            var result = await Task.Run(() => $"Status Serviço: {WindowsServices.StatusService()}\n" +
                                              $"{WindowsServices.CpuCounter()}\n" +
                                              $"{WindowsServices.MemoryCounter()}");
            var statuService = WindowsServices.StatusService();
            LblInfoService.Invoke(() =>
            {
                LblInfoService.Text = result;
            });

            if (statuService == "Em Execução")
            {
                SubMenuServiceStart.Enabled = false;
                SubMenuServiceStop.Enabled = true;
            }
            else
            {
                SubMenuServiceStart.Enabled = true;
                SubMenuServiceStop.Enabled = false;
            }

        }
        catch (Exception ex)
        {
            TimeMain.Stop();
            isTimerStop = true;
            MessageBox.Show(ex.Message, this.Text);
        }
    }

    private async Task<bool> IsFolderOffline()
    {
        var _folderOfflineRepository = _serviceProvider.GetRequiredService<IFolderOfflineRepository>();
        var isFolder = await _folderOfflineRepository.GetAll();

        foreach (var item in isFolder)
        {
            return item.IsOffline;
        }
        return false;
    }

    private void CheckEnvironmentVariable(string variableName, char dialogFlag)
    {
        if (EnvironmentVariables.IsVariableBD(variableName) || EnvironmentVariables.IsVariableKey(variableName))
        {
            MessageBox.Show($"Variável de ambiente {variableName} não encontrada", this.Text);
            FrmConfigurationBbAndVariables frmConfiguration = new(dialogFlag);
            frmConfiguration.ShowDialog();
        }
    }
    private void SubMenuAuthenticationSenior_Click(object sender, EventArgs e)
    {

    }
    private void SubMenuUrlBase_Click(object sender, EventArgs e)
    {

    }
    private void SubMenuUrlEndpoint_Click(object sender, EventArgs e)
    {

    }
    private void SubMenuPasta_Click(object sender, EventArgs e)
    {
        FrmFolder frmFolder = new(_serviceProvider.GetRequiredService<IFolderPastinhaRepository>());
        frmFolder.ShowDialog();
    }
    private void SubMenuGenerateKey_Click(object sender, EventArgs e)
    {
        FrmGenerateKey frmGenerateKey = new();
        frmGenerateKey.ShowDialog();
    }
    private void SubMenuServiceStart_Click(object sender, EventArgs e)
    {
        if (!Restart.IsRunningAsAdmin())
            if (MessageBox.Show("Para usar esse recurso precisa abrir o sistema como administrador.\nDeseja reiniciar como administrador?",
                this.Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
                Restart.RestartAsAdmin();
            else
                return;

        try
        {
            if (isTimerStop)
                TimeMain.Start();

            WindowsServices.StartService();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, this.Text);
        }
    }
    private void SubMenuServiceStop_Click(object sender, EventArgs e)
    {
        if (!Restart.IsRunningAsAdmin())
            if (MessageBox.Show("Para usar esse recurso precisa abrir o sistema como administrador.\nDeseja reiniciar como administrador?",
                this.Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
                Restart.RestartAsAdmin();

        try
        {
            WindowsServices.StopService();
            if (WindowsServices.StatusService() == "Parado")
            {
                TimeMain.Stop();
                isTimerStop = true;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, this.Text);
        }
    }
    private async void SubMenuOpenFolderInput_Click(object sender, EventArgs e)
    {
        try
        {
            await _folder.OpenInput();
        }
        catch (Win32Exception ex)
        {
            MessageBox.Show(ex.Message, this.Text);
        }
    }
    private async void SubMenuOpenFolderOutput_Click(object sender, EventArgs e)
    {
        try
        {
            await _folder.OpenOutput();
        }
        catch (Win32Exception ex)
        {

            MessageBox.Show(ex.Message, this.Text);
        }
    }
    private async void SubMenuOpenFolderError_Click(object sender, EventArgs e)
    {
        try
        {
            await _folder.OpenError();
        }
        catch (Win32Exception ex)
        {
            MessageBox.Show(ex.Message, this.Text);
        }
    }
    private async void SubMenuOpenFolderLog_Click(object sender, EventArgs e)
    {
        try
        {
            await _folder.OpenLog();
        }
        catch (Win32Exception ex)
        {

            MessageBox.Show(ex.Message, this.Text);
        }
    }
    private async void TimeMain_Tick(object sender, EventArgs e)
    {
        await InfoServicesAsync();
    }
    private async void FrmMain_Load(object sender, EventArgs e)
    {

        foreach (var arg in _args)
        {
            if (arg.Equals("config"))
                MenuConfiguracao.Visible = true;
        }

        try
        {
            if (!await _readPath.IsFolderCreated())
            {
                MessageBox.Show("Você precisa configurar pastas de Entrada, Saída e Log", this.Text);
                FrmFolder frmFolder = new(_serviceProvider.GetRequiredService<IFolderPastinhaRepository>())
                {
                    ShowInTaskbar = true
                };
                frmFolder.ShowDialog();
            }

            CheckEnvironmentVariable(Constants.PASTINHA_BD, 'B');
            CheckEnvironmentVariable(Constants.PASTINHA_KEY, 'K');

            LblInfoService.Text = $"Status Serviço: {WindowsServices.StatusService()}\n" +
                                  $"{WindowsServices.CpuCounter()}\n" +
                                  $"{WindowsServices.MemoryCounter()}";

            if (WindowsServices.StatusService() == "Parado")
            {
                SubMenuServiceStart.Enabled = true;
                SubMenuServiceStop.Enabled = false;
                TimeMain.Stop();
                isTimerStop = true;
            }
            else if (WindowsServices.StatusService() == "Em Execução")
            {
                SubMenuServiceStart.Enabled = false;
                SubMenuServiceStop.Enabled = true;
                TimeMain.Start();
                isTimerStop = false;
            }
        }
        catch (InvalidOperationException ex)
        {
            MessageBox.Show(ex.Message, this.Text);
        }
    }

    private void SubMenuAuthenticationSeniorLogin_Click(object sender, EventArgs e)
    {

    }

    private void SubMenuAuthenticationSeniorLoginWithKey_Click(object sender, EventArgs e)
    {

    }

    private void SubMenuGed_Click(object sender, EventArgs e)
    {

    }

    private void SubMenuReportList_Click(object sender, EventArgs e)
    {
        FrmGenerateReport frmGenerateReport = new(_serviceProvider);
        frmGenerateReport.ShowDialog();
    }

    private void SubMenuOffline_Click(object sender, EventArgs e)
    {
        FrmOffline frmOffline = new(_serviceProvider.GetRequiredService<IFolderOfflineRepository>());
        frmOffline.ShowDialog();
    }

    private void SubMenuStatusFired_Click(object sender, EventArgs e)
    {
        FrmStatusFired frmStatusFired = new(_serviceProvider.GetRequiredService<IStatusFiredRepository>());
        frmStatusFired.ShowDialog();
    }

    private async void SubMenuOpenFolderOffline_Click(object sender, EventArgs e)
    {
        try
        {
            var isFolderOffline = await IsFolderOffline();
            if (!isFolderOffline)
            {
                MessageBox.Show("Offline não configurado", this.Text);
                return;
            }

            await _folder.OpenOffline();
        }
        catch (Win32Exception ex)
        {
            MessageBox.Show(ex.Message, this.Text);
        }
    }

    private void SubMenuFromToEmpresa_Click(object sender, EventArgs e)
    {
        FrmFromTo frmFromTo = new(_serviceProvider.GetRequiredService<IFromToEmployeeRepository>(),
            _serviceProvider.GetRequiredService<IFromToCompanyRepository>(),
            _serviceProvider.GetRequiredService<IFromToTypeRepository>(),
            1);
        frmFromTo.ShowDialog();
    }

    private void SubMenuFromToTipoColaborador_Click(object sender, EventArgs e)
    {
        FrmFromTo frmFromTo = new(_serviceProvider.GetRequiredService<IFromToEmployeeRepository>(),
           _serviceProvider.GetRequiredService<IFromToCompanyRepository>(),
           _serviceProvider.GetRequiredService<IFromToTypeRepository>(),
           2);
        frmFromTo.ShowDialog();
    }

    private void SubMenuFromToColaborador_Click(object sender, EventArgs e)
    {
        FrmFromTo frmFromTo = new(_serviceProvider.GetRequiredService<IFromToEmployeeRepository>(),
           _serviceProvider.GetRequiredService<IFromToCompanyRepository>(),
           _serviceProvider.GetRequiredService<IFromToTypeRepository>(),
           3);
        frmFromTo.ShowDialog();
    }
}
