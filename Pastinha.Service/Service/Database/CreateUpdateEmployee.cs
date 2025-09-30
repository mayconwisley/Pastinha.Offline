using Microsoft.EntityFrameworkCore;
using Pastinha.Base.Model.Employee;
using Pastinha.Base.Repository.Interface;
using Pastinha.Service.Service.Database.Interface;
using Pastinha.Utility.Utility;

namespace Pastinha.Service.Service.Database;

public class CreateUpdateEmployee(IServiceScopeFactory _serviceScopeFactory, CreateLog _createLog) : ICreateUpdateEmployee
{
    public async Task CreateUpdadeAsync(Employee employee)
    {
        using var scope = _serviceScopeFactory.CreateScope();
        var _employeeRepository = scope.ServiceProvider.GetRequiredService<IEmployeeRepository>();

        try
        {
            var employeeCurrent = await _employeeRepository.GetByEmployeeAsync(employee.NumEmp, employee.TipCol, employee.NumCad);
            if (employeeCurrent is null)
                await _employeeRepository.CreateAsync(employee);
        }
        catch (DbUpdateException ex) when (ex.InnerException?.Message.Contains("UNIQUE constraint failed") == true)
        {
            _createLog.Log($"[AVISO] Colaborador já cadastradado {ex.Message}");
        }
        catch (Exception ex)
        {
            _createLog.Log($"[ERRO] {ex.Message}");
        }

    }
}
