using Microsoft.EntityFrameworkCore;
using Pastinha.Base.Database;
using Pastinha.Base.Model.FromTo;
using Pastinha.Base.Repository.Interface;

namespace Pastinha.Base.Repository;

public class FromToEmployeeRepository(PastinhaContext _pastinhaContext) : IFromToEmployeeRepository
{
    public async Task<FromToEmployee?> CreateAsync(FromToEmployee fromToEmployee)
    {
        try
        {
            if (fromToEmployee is null)
                return null;

            _pastinhaContext.FromToEmployees.Add(fromToEmployee);
            await _pastinhaContext.SaveChangesAsync();
            return fromToEmployee ?? null;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<FromToEmployee?> DeleteAsync(int id)
    {
        try
        {
            if (id <= 0)
                return null;

            var fromToEmployee = await GetByIdAsync(id);
            if (fromToEmployee is null)
                return null;

            _pastinhaContext.FromToEmployees.Remove(fromToEmployee);
            await _pastinhaContext.SaveChangesAsync();
            return fromToEmployee ?? null;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IEnumerable<FromToEmployee>?> GetAllAsync(int page = 1, int size = 15, string search = "")
    {
        try
        {
            var fromToEmployeeList = await _pastinhaContext.FromToEmployees
                .AsNoTracking()
                .Where(w => w.FromEmployee.ToString().Contains(search) ||
                                     w.ToEmployee.ToString().Contains(search))
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync();

            return fromToEmployeeList ?? [];
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<FromToEmployee?> GetByFromToEmployeeAsync(int fromNumCad)
    {
        try
        {
            var fromToEmployee = await _pastinhaContext.FromToEmployees
                .Where(w => w.FromEmployee == fromNumCad)
                .SingleOrDefaultAsync();
            return fromToEmployee ?? null;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<FromToEmployee?> GetByIdAsync(int id)
    {
        try
        {
            var fromToEmployee = await _pastinhaContext.FromToEmployees
                .Where(w => w.Id == id)
                .SingleOrDefaultAsync();
            return fromToEmployee ?? null;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<FromToEmployee?> UpdateAsync(FromToEmployee fromToEmployee)
    {
        try
        {
            if (fromToEmployee is null)
                return null;

            var fromToEmployeeCurrent = await GetByIdAsync(fromToEmployee.Id);
            if (fromToEmployeeCurrent is null)
                return null;

            _pastinhaContext.FromToEmployees.Entry(fromToEmployeeCurrent).CurrentValues.SetValues(fromToEmployee);
            await _pastinhaContext.SaveChangesAsync();
            return fromToEmployee;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
