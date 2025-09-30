using Pastinha.Base.Model.Fired;

namespace Pastinha.Service.Service.Database.Interface;

public interface IReturnStatusFired
{
    Task<IEnumerable<StatusFired>> GetStatusFiredAsync();
}
