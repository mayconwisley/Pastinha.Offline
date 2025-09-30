using Pastinha.Base.Model.Employee;

namespace Pastinha.Base.Repository.Interface;

public interface IEmployeeRepository
{
    Task<IEnumerable<Employee>?> GetAllAsync(int page = 1, int size = 15, string search = "");
    Task<Employee?> GetByIdAsync(int id);
    Task<Employee?> GetByEmployeeAsync(int numEmp, int tipCol, int numCad);
    Task<Employee?> CreateAsync(Employee employee);
    Task<Employee?> UpdateAsync(Employee employee);
    Task<Employee?> DeleteAsync(int id);
}
