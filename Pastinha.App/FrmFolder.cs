using Pastinha.Base.Model.Folder;
using Pastinha.Base.Repository.Interface;

namespace Pastinha.App;

public partial class FrmFolder : Form
{
	readonly IFolderPastinhaRepository _folderPastinha;
	int idFolderPastinha = 0;

	public FrmFolder(IFolderPastinhaRepository folderPastinha)
	{
		InitializeComponent();
		_folderPastinha = folderPastinha;
	}

	private async Task ListPaths()
	{
		try
		{
			DgvListPaths.DataSource = await _folderPastinha.GetAll();
			Buttons(DgvListPaths.RowCount);
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, this.Text);
		}
	}
	private void Buttons(int rows)
	{
		if (rows > 0)
		{
			BtnSave.Enabled = false;
			TxtPathInput.Enabled = false;
			TxtPathOutput.Enabled = false;
			TxtPathError.Enabled = false;
			TxtPathLog.Enabled = false;
			BtnSearchPathInput.Enabled = false;
			BtnSearchPathOutput.Enabled = false;
			BtnSearchPathLog.Enabled = false;
			BtnSearchPathError.Enabled = false;
			CbIsDelete.Enabled = false;
			NumDays.Enabled = false;
		}
		else
		{
			BtnSave.Enabled = true;
		}

	}
	private void ClearFields()
	{
		TxtPathInput.Clear();
		TxtPathOutput.Clear();
		TxtPathError.Clear();
		TxtPathLog.Clear();
		NumDays.Value = 30;
		CbIsDelete.Checked = false;
	}

	private static string OpenFolder()
	{
		FolderBrowserDialog dialog = new();
		if (dialog.ShowDialog() == DialogResult.OK)
			return dialog.SelectedPath;

		return string.Empty;
	}

	private async void FrmFolder_Load(object sender, EventArgs e)
	{
		await ListPaths();
	}

	private async void BtnSave_Click(object sender, EventArgs e)
	{
		try
		{
			FolderPastinhaSenior folderPastinhaSenior = new()
			{
				PathInput = TxtPathInput.Text.Trim(),
				PathOutput = TxtPathOutput.Text.Trim(),
				PathError = TxtPathError.Text.Trim(),
				PathLog = TxtPathLog.Text.Trim(),
				DaysDelete = (int)NumDays.Value
			};

			if (CbIsDelete.Checked)
				folderPastinhaSenior.IsDelete = true;
			else
				folderPastinhaSenior.IsDelete = false;

			if (folderPastinhaSenior is not null)
				await _folderPastinha.Create(folderPastinhaSenior);

			await ListPaths();
			ClearFields();
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
			FolderPastinhaSenior folderPastinhaSenior = new()
			{
				Id = idFolderPastinha,
				PathInput = TxtPathInput.Text.Trim(),
				PathOutput = TxtPathOutput.Text.Trim(),
				PathError = TxtPathError.Text.Trim(),
				PathLog = TxtPathLog.Text.Trim(),
				DaysDelete = (int)NumDays.Value
			};

			if (CbIsDelete.Checked)
				folderPastinhaSenior.IsDelete = true;
			else
				folderPastinhaSenior.IsDelete = false;


			if (folderPastinhaSenior is not null)
				await _folderPastinha.Update(folderPastinhaSenior);

			await ListPaths();
			ClearFields();
			BtnAlter.Enabled = false;
			BtnDelete.Enabled = false;
			Buttons(DgvListPaths.RowCount);
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
			await _folderPastinha.Delete(idFolderPastinha);
			await ListPaths();
			ClearFields();
			BtnAlter.Enabled = false;
			BtnDelete.Enabled = false;
			Buttons(DgvListPaths.RowCount);
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, this.Text);
		}
	}

	private void DgvListPaths_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			idFolderPastinha = int.Parse(DgvListPaths.Rows[e.RowIndex].Cells["Id"].Value.ToString()!);
			TxtPathInput.Text = DgvListPaths.Rows[e.RowIndex].Cells["PathInput"].Value.ToString();
			TxtPathOutput.Text = DgvListPaths.Rows[e.RowIndex].Cells["PathOutput"].Value.ToString();
			TxtPathError.Text = DgvListPaths.Rows[e.RowIndex].Cells["PathError"].Value.ToString();
			TxtPathLog.Text = DgvListPaths.Rows[e.RowIndex].Cells["PathLog"].Value.ToString();
			NumDays.Value = decimal.Parse(DgvListPaths.Rows[e.RowIndex].Cells["DaysDelete"].Value.ToString()!);
			CbIsDelete.Checked = bool.Parse(DgvListPaths.Rows[e.RowIndex].Cells["IsDelete"].Value.ToString()!);

			Buttons(DgvListPaths.RowCount);
			BtnAlter.Enabled = true;
			BtnDelete.Enabled = true;
			TxtPathInput.Enabled = true;
			TxtPathOutput.Enabled = true;
			TxtPathError.Enabled = true;
			TxtPathLog.Enabled = true;
			BtnSearchPathInput.Enabled = true;
			BtnSearchPathOutput.Enabled = true;
			BtnSearchPathLog.Enabled = true;
			BtnSearchPathError.Enabled = true;
			CbIsDelete.Enabled = true;
			NumDays.Enabled = true;

		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, this.Text);
		}
	}

	private void BtnSearchPathInput_Click(object sender, EventArgs e)
	{
		TxtPathInput.Text = OpenFolder();
	}

	private void BtnSearchPathOutput_Click(object sender, EventArgs e)
	{
		TxtPathOutput.Text = OpenFolder();
	}

	private void BtnSearchPathLog_Click(object sender, EventArgs e)
	{
		TxtPathLog.Text = OpenFolder();
	}

	private void BtnSearchPathError_Click(object sender, EventArgs e)
	{
		TxtPathError.Text = OpenFolder();
	}
}
