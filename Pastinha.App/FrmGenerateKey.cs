using Pastinha.Utility.Utility;

namespace Pastinha.App;

public partial class FrmGenerateKey : Form
{
	public FrmGenerateKey()
	{
		InitializeComponent();
	}

	private void Key()
	{
		try
		{
			decimal amount = NumAmount.Value;
			byte[] bytes = new byte[int.Parse(CbxBytes.Text.Trim())];
			var strKey = GenerateKey.GetGenerateKey(amount, bytes);

			RTxtKeys.Text = strKey.ToString().Trim();
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, this.Text);
		}
	}

	private void BtnGenerate_Click(object sender, EventArgs e)
	{
		Key();
	}

	private void FrmGenerateKey_Load(object sender, EventArgs e)
	{
		CbxBytes.SelectedIndex = 2;
	}
}
