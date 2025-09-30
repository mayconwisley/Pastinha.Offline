using Pastinha.Base.Model.FromTo;
using Pastinha.Base.Repository.Interface;
using Pastinha.Service.Service.Database.Interface;

namespace Pastinha.Service.Service.Database;

public class ReturnFromTo(IServiceScopeFactory _serviceScopeFactory) : IReturnFromTo
{
    public async Task<FromToCompany?> GetFromToCompany(int fromNumEmp)
    {
        try
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var fromToCompany = scope.ServiceProvider.GetRequiredService<IFromToCompanyRepository>();
            var toCompany = await fromToCompany.GetByFromToCompanyAsync(fromNumEmp);

            return toCompany ?? null;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<FromToEmployee?> GetFromToEmployee(int fromNumCad)
    {
        try
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var fromToEmployee = scope.ServiceProvider.GetRequiredService<IFromToEmployeeRepository>();
            var toEmployee = await fromToEmployee.GetByFromToEmployeeAsync(fromNumCad);

            return toEmployee ?? null;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<FromToType?> GetFromToType(int fromTipCol)
    {
        try
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var fromToType = scope.ServiceProvider.GetRequiredService<IFromToTypeRepository>();
            var toType = await fromToType.GetByFromToTypeAsync(fromTipCol);

            return toType ?? null;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
