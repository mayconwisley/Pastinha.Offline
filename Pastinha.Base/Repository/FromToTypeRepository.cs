using Microsoft.EntityFrameworkCore;
using Pastinha.Base.Database;
using Pastinha.Base.Model.FromTo;
using Pastinha.Base.Repository.Interface;

namespace Pastinha.Base.Repository;

public class FromToTypeRepository(PastinhaContext _pastinhaContext) : IFromToTypeRepository
{
    public async Task<FromToType?> CreateAsync(FromToType fromToType)
    {
        try
        {
            if (fromToType is null)
                return null;

            _pastinhaContext.FromToTypes.Add(fromToType);
            await _pastinhaContext.SaveChangesAsync();
            return fromToType ?? null;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<FromToType?> DeleteAsync(int id)
    {
        try
        {
            if (id <= 0)
                return null;

            var fromToType = await GetByIdAsync(id);
            if (fromToType is null)
                return null;

            _pastinhaContext.FromToTypes.Remove(fromToType);
            await _pastinhaContext.SaveChangesAsync();
            return fromToType ?? null;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IEnumerable<FromToType>?> GetAllAsync(int page = 1, int size = 15, string search = "")
    {
        try
        {
            var fromToTypeList = await _pastinhaContext.FromToTypes
                .AsNoTracking()
                .Where(w => w.FromType.ToString().Contains(search) ||
                                     w.ToType.ToString().Contains(search))
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync();

            return fromToTypeList ?? [];
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<FromToType?> GetByFromToTypeAsync(int fromTipCol)
    {
        try
        {
            var fromToType = await _pastinhaContext.FromToTypes
                .Where(w => w.FromType == fromTipCol)
                .SingleOrDefaultAsync();
            return fromToType ?? null;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<FromToType?> GetByIdAsync(int id)
    {
        try
        {
            var fromToType = await _pastinhaContext.FromToTypes
                .Where(w => w.Id == id)
                .SingleOrDefaultAsync();
            return fromToType ?? null;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<FromToType?> UpdateAsync(FromToType fromToType)
    {
        try
        {
            if (fromToType is null)
                return null;

            var fromToTypeCurrent = await GetByIdAsync(fromToType.Id);
            if (fromToTypeCurrent is null)
                return null;

            _pastinhaContext.FromToTypes.Entry(fromToTypeCurrent).CurrentValues.SetValues(fromToType);
            await _pastinhaContext.SaveChangesAsync();
            return fromToType;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
