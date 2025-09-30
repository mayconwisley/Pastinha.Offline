using Pastinha.Base.Model.Fired;
using Pastinha.Base.Repository.Interface;

namespace Pastinha.App;

public partial class FrmStatusFired : Form
{
	readonly IStatusFiredRepository _statusFiredRepository;
	int idStatusFired;

	public FrmStatusFired(IStatusFiredRepository statusFiredRepository)
	{
		InitializeComponent();
		_statusFiredRepository = statusFiredRepository;
	}

	private async Task ListStatusFired()
	{
		try
		{
			DgvData.DataSource = await _statusFiredRepository.GetAll();
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, this.Text);
		}
	}
	private void ClearFields()
	{
		TxtCode.Clear();
		TxtDescription.Clear();
	}

	private async void FrmStatusFired_Load(object sender, EventArgs e)
	{
		await ListStatusFired();
	}

	private async void BtnSave_Click(object sender, EventArgs e)
	{
		try
		{
			StatusFired statusFired = new()
			{
				CodeStatus = int.Parse(TxtCode.Text),
				Description = TxtDescription.Text,
			};

			await _statusFiredRepository.Create(statusFired);
			await ListStatusFired();
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
			StatusFired statusFired = new()
			{
				Id = idStatusFired,
				CodeStatus = int.Parse(TxtCode.Text),
				Description = TxtDescription.Text,
			};

			await _statusFiredRepository.Update(statusFired);
			await ListStatusFired();
			ClearFields();
			BtnSave.Enabled = true;
			BtnAlter.Enabled = false;
			BtnDelete.Enabled = false;

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
			await _statusFiredRepository.Delete(idStatusFired);
			await ListStatusFired();
			ClearFields();
			BtnSave.Enabled = true;
			BtnAlter.Enabled = false;
			BtnDelete.Enabled = false;

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
			idStatusFired = int.Parse(DgvData.Rows[e.RowIndex].Cells["Id"].Value.ToString()!);
			TxtCode.Text = DgvData.Rows[e.RowIndex].Cells["CodeStatus"].Value.ToString();
			TxtDescription.Text = DgvData.Rows[e.RowIndex].Cells["Description"].Value.ToString();

			BtnSave.Enabled = false;
			BtnAlter.Enabled = true;
			BtnDelete.Enabled = true;
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, this.Text);
		}
	}
}
