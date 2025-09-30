using Pastinha.Base.Model.FromTo;
using Pastinha.Base.Repository.Interface;

namespace Pastinha.App;

public partial class FrmFromTo : Form
{
    readonly IFromToEmployeeRepository _fromToEmployeeRepository;
    readonly IFromToCompanyRepository _fromToCompanyRepository;
    readonly IFromToTypeRepository _fromToTypeRepository;
    readonly int _tipoDeInicialiacao = 0; /*1 = Empresa, 2 = Tipo Colaborador, 3 = Colaborador */

    public FrmFromTo(IFromToEmployeeRepository fromToEmployeeRepository, IFromToCompanyRepository fromToCompanyRepository,
        IFromToTypeRepository fromToTypeRepository, int tipoDeInicialiacao)
    {
        InitializeComponent();
        _fromToEmployeeRepository = fromToEmployeeRepository;
        _fromToCompanyRepository = fromToCompanyRepository;
        _fromToTypeRepository = fromToTypeRepository;
        _tipoDeInicialiacao = tipoDeInicialiacao;
    }

    int idFromTo;
    private async Task ListFromTo()
    {
        switch (_tipoDeInicialiacao)
        {
            case 1:
                DgvListFromTo.DataSource = await _fromToCompanyRepository.GetAllAsync();
                break;
            case 2:
                DgvListFromTo.DataSource = await _fromToTypeRepository.GetAllAsync();
                break;
            case 3:
                DgvListFromTo.DataSource = await _fromToEmployeeRepository.GetAllAsync();
                break;
            default:
                MessageBox.Show("Dados Invalidos");
                break;
        }
    }

    private void ClearFields()
    {
        TxtFrom.Clear();
        TxtTo.Clear();
    }

    private async void FrmFromTo_Load(object sender, EventArgs e)
    {
        switch (_tipoDeInicialiacao)
        {
            case 1:
                this.Text = "De Para Empresa";
                break;
            case 2:
                this.Text = "De Para Tipo de Colaborador";
                break;
            case 3:
                this.Text = "De Para Colaborador";
                break;
            default:
                MessageBox.Show("Dados Invalidos");
                break;
        }
        await ListFromTo();
    }

    private async void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            switch (_tipoDeInicialiacao)
            {
                case 1:

                    FromToCompany fromToCompany = new()
                    {
                        FromCompany = int.Parse(TxtFrom.Text.Trim()),
                        ToCompany = int.Parse(TxtTo.Text.Trim())
                    };
                    await _fromToCompanyRepository.CreateAsync(fromToCompany);
                    break;
                case 2:
                    FromToType fromToType = new()
                    {
                        FromType = int.Parse(TxtFrom.Text.Trim()),
                        ToType = int.Parse(TxtTo.Text.Trim())
                    };
                    await _fromToTypeRepository.CreateAsync(fromToType);
                    break;
                case 3:
                    FromToEmployee fromToEmployee = new()
                    {
                        FromEmployee = int.Parse(TxtFrom.Text.Trim()),
                        ToEmployee = int.Parse(TxtTo.Text.Trim())
                    };
                    await _fromToEmployeeRepository.CreateAsync(fromToEmployee);
                    break;
                default:
                    MessageBox.Show("Dados Invalidos");
                    break;
            }
            await ListFromTo();
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
            switch (_tipoDeInicialiacao)
            {
                case 1:

                    FromToCompany fromToCompany = new()
                    {
                        FromCompany = int.Parse(TxtFrom.Text.Trim()),
                        ToCompany = int.Parse(TxtTo.Text.Trim())
                    };
                    await _fromToCompanyRepository.UpdateAsync(fromToCompany);
                    break;
                case 2:
                    FromToType fromToType = new()
                    {
                        FromType = int.Parse(TxtFrom.Text.Trim()),
                        ToType = int.Parse(TxtTo.Text.Trim())
                    };
                    await _fromToTypeRepository.UpdateAsync(fromToType);
                    break;
                case 3:
                    FromToEmployee fromToEmployee = new()
                    {
                        FromEmployee = int.Parse(TxtFrom.Text.Trim()),
                        ToEmployee = int.Parse(TxtTo.Text.Trim())
                    };
                    await _fromToEmployeeRepository.UpdateAsync(fromToEmployee);
                    break;
                default:
                    MessageBox.Show("Dados Invalidos");
                    break;
            }
            await ListFromTo();
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
            switch (_tipoDeInicialiacao)
            {
                case 1:
                    await _fromToCompanyRepository.DeleteAsync(idFromTo);
                    break;
                case 2:
                    await _fromToTypeRepository.DeleteAsync(idFromTo);
                    break;
                case 3:
                    await _fromToEmployeeRepository.DeleteAsync(idFromTo);
                    break;
                default:
                    MessageBox.Show("Dados Inválidos");
                    break;
            }
            await ListFromTo();
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

    private void DgvListFromTo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        try
        {
            idFromTo = int.Parse(DgvListFromTo.Rows[e.RowIndex].Cells[0].Value.ToString()!);
            TxtFrom.Text = DgvListFromTo.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtTo.Text = DgvListFromTo.Rows[e.RowIndex].Cells[2].Value.ToString();

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
