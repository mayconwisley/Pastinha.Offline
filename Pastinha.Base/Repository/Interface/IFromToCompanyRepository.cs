using Pastinha.Base.Model.FromTo;

namespace Pastinha.Base.Repository.Interface;

public interface IFromToCompanyRepository
{
    Task<IEnumerable<FromToCompany>?> GetAllAsync(int page = 1, int size = 15, string search = "");
    Task<FromToCompany?> GetByIdAsync(int id);
    Task<FromToCompany?> GetByFromToCompanyAsync(int fromNumEmp);
    Task<FromToCompany?> CreateAsync(FromToCompany fromToCompany);
    Task<FromToCompany?> UpdateAsync(FromToCompany fromToCompany);
    Task<FromToCompany?> DeleteAsync(int id);
}
