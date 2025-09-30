using Pastinha.Base.Model.Employee;
using Pastinha.Model.Model;

namespace Pastinha.Service.Service.Dto.Mapping;

public static class MappingEmployee
{
	public static Employee ToQrCodeDataFromEmploye(this DataQrCode dataQrCode)
	{
		return new Employee(dataQrCode.NumEmp, dataQrCode.TipCol, dataQrCode.NumCad, dataQrCode.SitAfa, dataQrCode.NomFun);
	}
}
