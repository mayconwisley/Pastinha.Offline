using Pastinha.Base.Model.Fired;
using Pastinha.Base.Repository.Interface;
using Pastinha.Service.Service.Database.Interface;

namespace Pastinha.Service.Service.Database;

public class ReturnStatusFired(IServiceScopeFactory _serviceScopeFactory) : IReturnStatusFired
{
    public async Task<IEnumerable<StatusFired>> GetStatusFiredAsync()
    {
        using var scope = _serviceScopeFactory.CreateScope();
        var statusFired = scope.ServiceProvider.GetRequiredService<IStatusFiredRepository>();

        var statusFiredList = await statusFired.GetAll();
        return statusFiredList;
    }
}
