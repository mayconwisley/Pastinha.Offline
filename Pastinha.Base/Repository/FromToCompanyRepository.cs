using Microsoft.EntityFrameworkCore;
using Pastinha.Base.Database;
using Pastinha.Base.Model.FromTo;
using Pastinha.Base.Repository.Interface;

namespace Pastinha.Base.Repository;

public class FromToCompanyRepository(PastinhaContext _pastinhaContext) : IFromToCompanyRepository
{
    public async Task<FromToCompany?> CreateAsync(FromToCompany fromToCompany)
    {
        try
        {
            if (fromToCompany is null)
                return null;

            _pastinhaContext.FromToCompanies.Add(fromToCompany);
            await _pastinhaContext.SaveChangesAsync();
            return fromToCompany ?? null;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<FromToCompany?> DeleteAsync(int id)
    {
        try
        {
            if (id <= 0)
                return null;

            var fromToCompany = await GetByIdAsync(id);
            if (fromToCompany is null)
                return null;

            _pastinhaContext.FromToCompanies.Remove(fromToCompany);
            await _pastinhaContext.SaveChangesAsync();
            return fromToCompany ?? null;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IEnumerable<FromToCompany>?> GetAllAsync(int page = 1, int size = 15, string search = "")
    {
        try
        {
            var fromToCompanyList = await _pastinhaContext.FromToCompanies
                .AsNoTracking()
                .Where(w => w.FromCompany.ToString().Contains(search) ||
                                     w.ToCompany.ToString().Contains(search))
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync();

            return fromToCompanyList ?? [];
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<FromToCompany?> GetByFromToCompanyAsync(int fromNumEmp)
    {
        try
        {
            var fromToCompany = await _pastinhaContext.FromToCompanies
                .Where(w => w.FromCompany == fromNumEmp)
                .SingleOrDefaultAsync();
            return fromToCompany ?? null;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<FromToCompany?> GetByIdAsync(int id)
    {
        try
        {
            var fromToCompany = await _pastinhaContext.FromToCompanies
                .Where(w => w.Id == id)
                .SingleOrDefaultAsync();
            return fromToCompany ?? null;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<FromToCompany?> UpdateAsync(FromToCompany fromToCompany)
    {
        try
        {
            if (fromToCompany is null)
                return null;

            var fromToCompanyCurrent = await GetByIdAsync(fromToCompany.Id);
            if (fromToCompanyCurrent is null)
                return null;

            _pastinhaContext.FromToCompanies.Entry(fromToCompanyCurrent).CurrentValues.SetValues(fromToCompany);
            await _pastinhaContext.SaveChangesAsync();
            return fromToCompany;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
