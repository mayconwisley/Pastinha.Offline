using Pastinha.Base.Model.Folder;
using Pastinha.Base.Repository.Interface;

namespace Pastinha.App;

public partial class FrmOffline : Form
{
    readonly IFolderOfflineRepository _folderOfflineRepository;
    int idFolderOffline;
    public FrmOffline(IFolderOfflineRepository folderOfflineRepository)
    {
        InitializeComponent();
        _folderOfflineRepository = folderOfflineRepository;
    }

    private async Task ListPaths()
    {
        try
        {
            DgvData.DataSource = await _folderOfflineRepository.GetAll();
            Buttons(DgvData.RowCount);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, this.Text);
        }
    }
    private void Buttons(int rows)
    {
        if (rows > 0)
            BtnSave.Enabled = false;
        else
            BtnSave.Enabled = true;
    }
    private void ClearFields()
    {
        TxtSeacherPath.Clear();
    }

    private static string OpenFolder()
    {
        FolderBrowserDialog dialog = new();
        if (dialog.ShowDialog() == DialogResult.OK)
            return dialog.SelectedPath;

        return string.Empty;
    }

    private async void FrmOffline_Load(object sender, EventArgs e)
    {
        await ListPaths();
    }

    private async void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            FolderOfflinePastinhaSenior folderOfflinePastinhaSenior = new()
            {
                IsOffline = true,
                PathOffline = TxtSeacherPath.Text.Trim()
            };

            if (folderOfflinePastinhaSenior is not null)
                await _folderOfflineRepository.Create(folderOfflinePastinhaSenior);

            await ListPaths();
            ClearFields();

            MessageBox.Show("É necessário reiniciar o serviço do QrCode para que o sistema possa" +
                            " ler essas novas configurações", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, this.Text);
        }
    }

    private async void BtnAlter_Click(object sender, EventArgs e)
    {
        try
        {
            FolderOfflinePastinhaSenior folderOfflinePastinhaSenior = new()
            {
                Id = idFolderOffline,
                IsOffline = true,
                PathOffline = TxtSeacherPath.Text.Trim()
            };

            if (folderOfflinePastinhaSenior is not null)
                await _folderOfflineRepository.Update(folderOfflinePastinhaSenior);

            await ListPaths();
            ClearFields();
            BtnAlter.Enabled = false;
            BtnDelete.Enabled = false;
            Buttons(DgvData.RowCount);

            MessageBox.Show("É necessário reiniciar o serviço do QrCode para que o sistema possa" +
                            " ler essas novas configurações", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, this.Text);
        }
    }

    private async void BtnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            await _folderOfflineRepository.Delete(idFolderOffline);
            await ListPaths();
            ClearFields();
            BtnAlter.Enabled = false;
            BtnDelete.Enabled = false;
            Buttons(DgvData.RowCount);

            MessageBox.Show("É necessário reiniciar o serviço do QrCode para que o sistema possa" +
                           " ler essas novas configurações", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, this.Text);
        }
    }

    private void DgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        try
        {
            idFolderOffline = int.Parse(DgvData.Rows[e.RowIndex].Cells["Id"].Value.ToString()!);
            TxtSeacherPath.Text = DgvData.Rows[e.RowIndex].Cells[columnName: "PathOffline"].Value.ToString();
            var isOffline = (bool)DgvData.Rows[e.RowIndex].Cells[columnName: "IsOffline"].Value;

            BtnAlter.Enabled = true;
            BtnDelete.Enabled = true;
            Buttons(DgvData.RowCount);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, this.Text);
        }
    }

    private void BtnSearchPath_Click(object sender, EventArgs e)
    {
        TxtSeacherPath.Text = OpenFolder();
    }
}
