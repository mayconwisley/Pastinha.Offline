using Pastinha.Base.Model.Employee;

namespace Pastinha.Service.Service.Database.Interface;

public interface ICreateUpdateEmployee
{
    Task CreateUpdadeAsync(Employee employee);
}
