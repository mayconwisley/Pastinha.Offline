using Pastinha.Base.Model.FromTo;

namespace Pastinha.Base.Repository.Interface;

public interface IFromToEmployeeRepository
{
    Task<IEnumerable<FromToEmployee>?> GetAllAsync(int page = 1, int size = 15, string search = "");
    Task<FromToEmployee?> GetByIdAsync(int id);
    Task<FromToEmployee?> GetByFromToEmployeeAsync(int fromNumCad);
    Task<FromToEmployee?> CreateAsync(FromToEmployee fromToEmployee);
    Task<FromToEmployee?> UpdateAsync(FromToEmployee fromToEmployee);
    Task<FromToEmployee?> DeleteAsync(int id);
}
