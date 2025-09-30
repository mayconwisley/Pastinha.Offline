using Pastinha.Base.Model.FromTo;

namespace Pastinha.Service.Service.Database.Interface;

public interface IReturnFromTo
{
    Task<FromToCompany?> GetFromToCompany(int fromNumEmp);
    Task<FromToEmployee?> GetFromToEmployee(int fromNumCad);
    Task<FromToType?> GetFromToType(int fromTipCol);
}
