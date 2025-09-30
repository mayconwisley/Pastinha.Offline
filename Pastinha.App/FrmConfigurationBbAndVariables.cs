using Pastinha.App.RestartAdmin;
using Pastinha.App.UpMigration;
using Pastinha.Utility.Constant;
using Pastinha.Utility.Utility;
using System.Security;

namespace Pastinha.App;

public partial class FrmConfigurationBbAndVariables : Form
{
	public FrmConfigurationBbAndVariables()
	{
		InitializeComponent();
		PbSalvando.Visible = false;
		LblInfoSalvando.Visible = false;
	}

	private readonly char _opc = 'G';
	public FrmConfigurationBbAndVariables(char opc) : base()
	{
		_opc = opc;
	}

	private async Task Salvando()
	{
		try
		{
			ToggleUI(false);
			MostrarProgresso(true);

			await Task.Run(SaveEnvironmentVariables);

			MessageBox.Show("Variáveis de ambiente salvas com sucesso!", this.Text);
		}
		catch (SecurityException)
		{
			MessageBox.Show("Execute o aplicativo como Administrador para salvar as variáveis de ambiente do sistema.", this.Text);
			Application.Exit();
		}
		catch (Exception ex)
		{
			MessageBox.Show($"Erro ao salvar variáveis de ambiente:\n{ex.Message}", this.Text);
		}
		finally
		{
			MostrarProgresso(false);
			ToggleUI(true);
		}
	}
	private void ToggleUI(bool enabled)
	{
		TxtKey.Enabled = enabled;
		TxtPathBd.Enabled = enabled;
		BtnSave.Enabled = enabled;
		BtnGenerateKey.Enabled = enabled;
		BtnSearch.Enabled = enabled;
	}

	private void MostrarProgresso(bool mostrar)
	{
		PbSalvando.Visible = true;
		LblInfoSalvando.Visible = true;
		PbSalvando.Style = ProgressBarStyle.Marquee;
		PbSalvando.MarqueeAnimationSpeed = mostrar ? 30 : 0;
	}
	private void Key()
	{
		try
		{
			decimal amount = 1;
			byte[] bytes = new byte[int.Parse(CbxBytes.Text.Trim())];
			var strKey = GenerateKey.GetGenerateKey(amount, bytes);

			TxtKey.Text = strKey.ToString().Trim();
		}
		catch (InvalidOperationException ex)
		{
			MessageBox.Show(ex.Message, this.Text);
		}
	}
	private string GetApplicationDirectory()
	{
		return AppDomain.CurrentDomain.BaseDirectory;
	}
	private void OpenDirectoryDialog()
	{
		using FolderBrowserDialog folderBrowserDialog = new();
		if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
			TxtPathBd.Text = folderBrowserDialog.SelectedPath;
	}

	private void SaveEnvironmentVariables()
	{
		try
		{
			var dbPath = TxtPathBd.Text.Trim();
			var bdPastinha = Path.Combine(dbPath, @"PastinhaDb.db");

			Environment.SetEnvironmentVariable(Constants.PASTINHA_KEY, TxtKey.Text.Trim(), EnvironmentVariableTarget.Machine);
			Environment.SetEnvironmentVariable(Constants.PASTINHA_BD, bdPastinha, EnvironmentVariableTarget.Machine);
		}
		catch (SecurityException ex)
		{
			MessageBox.Show($"Executar a aplicação como Administrador,\n" +
							$"para que seja instalada as variaveis do sistema\n" +
							$"{ex.Message}", this.Text);
			Application.Exit();
		}
	}
	private void BtnGenerateKey_Click(object sender, EventArgs e)
	{
		Key();
		if ((_opc == 'K' || _opc == 'G') && TxtKey.Text != string.Empty)
			BtnSave.Enabled = true;
		else
			BtnSave.Enabled = false;
	}
	private void FrmConfigurationBbAndVariables_Load(object sender, EventArgs e)
	{
		CbxBytes.SelectedIndex = 2;
		TxtPathBd.Text = GetApplicationDirectory();

		if (!Restart.IsRunningAsAdmin())
		{
			MessageBox.Show("Reiniciando sistema como administrador, para gravar as variáveis de ambiente.", this.Text, MessageBoxButtons.OK);
			Restart.RestartAsAdmin();
		}

		if (_opc == 'B')
			GbKey.Enabled = false;
		else if (_opc == 'K')
			GbBD.Enabled = false;
	}
	private void BtnSearch_Click(object sender, EventArgs e)
	{
		OpenDirectoryDialog();
		if ((_opc == 'K' || _opc == 'G') && TxtPathBd.Text != string.Empty)
			BtnSave.Enabled = true;
		else
			BtnSave.Enabled = false;
	}
	private async void BtnSave_Click(object sender, EventArgs e)
	{
		if (TxtKey.Text == string.Empty || TxtKey.Text == "")
		{
			MessageBox.Show("É preciso gerar a chave antes de salvar!", this.Text);
			return;
		}

		if (TxtPathBd.Text == string.Empty || TxtPathBd.Text == "")
		{
			MessageBox.Show("É preciso informar o diretório do banco de dados antes de salvar!", this.Text);
			return;
		}

		await Salvando();

		if (_opc != 'K')
		{
			UpdateMigration.MigrationDataBase();

			if (!Restart.IsRunningAsAdmin())
				Restart.RestartAsAdmin();
			else
				Application.Restart();
		}
	}
	private void FrmConfigurationBbAndVariables_FormClosing(object sender, FormClosingEventArgs e)
	{
		Application.Exit();
	}
}