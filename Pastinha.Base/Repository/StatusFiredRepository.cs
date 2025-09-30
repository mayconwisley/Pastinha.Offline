using Microsoft.EntityFrameworkCore;
using Pastinha.Base.Database;
using Pastinha.Base.Model.Fired;
using Pastinha.Base.Repository.Interface;

namespace Pastinha.Base.Repository;

public class StatusFiredRepository(PastinhaContext _pastinhaContext) : IStatusFiredRepository
{
    public async Task<StatusFired> Create(StatusFired statusFired)
    {
        if (statusFired is null)
            throw new ArgumentException("Objeto para criação do status nulo");

        _pastinhaContext.StatusFireds.Add(statusFired);
        await _pastinhaContext.SaveChangesAsync();
        return statusFired;
    }

    public async Task<StatusFired> Delete(int id)
    {
        if (id <= 0)
            throw new ArgumentException("Id inválido");

        var statusFired = await GetById(id) ?? throw new ArgumentException("Status não encontrado");

        _pastinhaContext.StatusFireds.Remove(statusFired);
        await _pastinhaContext.SaveChangesAsync();

        return statusFired;
    }

    public async Task<IEnumerable<StatusFired>> GetAll(int page = 1, int size = 15, string search = "")
    {
        var statusFiresList = await _pastinhaContext.StatusFireds
             .AsNoTracking()
             .Where(w => w.Description.ToLower().Contains(search.ToLower()))
             .OrderBy(o => o.Description)
             .Skip((page - 1) * size)
             .Take(size)
             .ToListAsync();

        return statusFiresList;
    }

    public async Task<StatusFired> GetById(int id)
    {
        if (id <= 0)
            throw new ArgumentException("Id inválifo");

        var statusFired = await _pastinhaContext.StatusFireds.FindAsync(id);

        return statusFired is null ? throw new ArgumentException("Status não encontrado") : statusFired;
    }

    public async Task<StatusFired> GetByName(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("Descrição vazia ou nula");

        var statusFired = await _pastinhaContext.StatusFireds
            .Where(w => w.Description.ToLower().Contains(name.ToLower()))
            .FirstOrDefaultAsync();

        return statusFired is null ? throw new ArgumentException("Status não encontrado") : statusFired;
    }

    public async Task<StatusFired> Update(StatusFired statusFired)
    {
        if (statusFired is null)
            throw new ArgumentException("Objeto para atualização do status nulo");

        var statusFiredCurrent = await GetById(statusFired.Id) ?? throw new ArgumentException("Status não encontrado");

        _pastinhaContext.Entry(statusFiredCurrent).CurrentValues.SetValues(statusFired);
        await _pastinhaContext.SaveChangesAsync();

        return statusFired;
    }
}
