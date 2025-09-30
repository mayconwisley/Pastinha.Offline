using Microsoft.Extensions.DependencyInjection;
using Pastinha.Base.Repository.Interface;

namespace Pastinha.App;

public partial class FrmGenerateReport : Form
{
	readonly IServiceProvider _serviceProvider;
	public FrmGenerateReport(IServiceProvider serviceProvider)
	{
		InitializeComponent();
		_serviceProvider = serviceProvider;
	}

	private void FrmGenerateReport_Load(object sender, EventArgs e)
	{
		MktDateInitialReport.Text = DateTime.Now.Date.ToString("01/MM/yyyy");
		MktDateFinalReport.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
	}

	private async Task GerarRelatorio(DateTime dateInicial, DateTime dateFinal)
	{
		ToggleUI(false);
		MostrarProgresso();

		await Task.Run(() =>
		{
			FrmViewReport frmViewReport = new(_serviceProvider.GetRequiredService<ICountDataFileRepository>(),
											dateInicial, dateFinal);
			frmViewReport.ShowDialog();
		});
		ToggleUI();
		MostrarProgresso(false);
	}

	private void ToggleUI(bool enabled = true)
	{
		MktDateInitialReport.Enabled = enabled;
		MktDateFinalReport.Enabled = enabled;
		BtnGenerate.Enabled = enabled;
	}

	private void MostrarProgresso(bool mostrar = true)
	{
		PbProcessando.Visible = mostrar;
		LblProcessando.Visible = mostrar;
		PbProcessando.Style = ProgressBarStyle.Marquee;
		PbProcessando.MarqueeAnimationSpeed = mostrar ? 15 : 0;
	}

	private async void BtnGenerate_Click(object sender, EventArgs e)
	{
		DateTime dateInicial = DateTime.Parse(MktDateInitialReport.Text.Trim());
		DateTime dateFinal = DateTime.Parse(MktDateFinalReport.Text.Trim());

		await GerarRelatorio(dateInicial, dateFinal);
	}
}
