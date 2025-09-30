using Pastinha.Base.Model.Fired;

namespace Pastinha.Base.Repository.Interface;

public interface IStatusFiredRepository
{
    Task<IEnumerable<StatusFired>> GetAll(int page = 1, int size = 15, string search = "");
    Task<StatusFired> GetByName(string name);
    Task<StatusFired> GetById(int id);
    Task<StatusFired> Create(StatusFired statusFired);
    Task<StatusFired> Update(StatusFired statusFired);
    Task<StatusFired> Delete(int id);
}
