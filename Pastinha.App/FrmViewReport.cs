using Microsoft.Reporting.WinForms;
using Pastinha.Base.Repository.Interface;

namespace Pastinha.App;

public partial class FrmViewReport : Form
{
    readonly ICountDataFileRepository _countDataFileRepository;
    readonly DateTime _dateInitial, _dateFinal;
    public FrmViewReport(ICountDataFileRepository countDataFileRepository, DateTime dateInitial, DateTime dateFinal)
    {
        InitializeComponent();
        InitializeReportViewer();

        _countDataFileRepository = countDataFileRepository;
        _dateInitial = dateInitial;
        _dateFinal = dateFinal;
    }

    private void InitializeReportViewer()
    {
        reportViewer1 = new ReportViewer
        {
            Dock = DockStyle.Fill,
            ShowBackButton = false,
            ShowFindControls = false,
            ShowRefreshButton = false,
            ShowStopButton = false,
            ShowDocumentMapButton = false
        };

        this.Controls.Add(reportViewer1);
    }

    private async void FrmViewReport_Load(object sender, EventArgs e)
    {
        try
        {
            string reportPath = Path.Combine(Application.StartupPath, "Reports", "ReportProcessQrCode.rdlc");
            var countDataFile = await _countDataFileRepository.GetByDate(_dateInitial, _dateFinal);

            reportViewer1.LocalReport.ReportPath = reportPath;
            reportViewer1.LocalReport.DataSources.Clear();

            var reportDataSource = new ReportDataSource("DataQrCodeProcess", countDataFile);
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);

            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.PageWidth;

            reportViewer1.RefreshReport();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, this.Text);
        }
    }
}
