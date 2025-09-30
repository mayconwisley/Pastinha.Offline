using Microsoft.EntityFrameworkCore;
using Pastinha.Base.Database;
using Pastinha.Base.Model.Employee;
using Pastinha.Base.Repository.Interface;

namespace Pastinha.Base.Repository;

public class EmployeeRepository(PastinhaContext _pastinhaContext) : IEmployeeRepository
{
    public async Task<Employee?> CreateAsync(Employee employee)
    {
        try
        {
            if (employee is null)
                return null;

            _pastinhaContext.Employees.Add(employee);
            await _pastinhaContext.SaveChangesAsync();
            return employee;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<Employee?> DeleteAsync(int id)
    {
        try
        {
            if (id <= 0)
                return null;

            var employee = await GetByIdAsync(id);
            if (employee is null)
                return null;

            _pastinhaContext.Employees.Remove(employee);
            await _pastinhaContext.SaveChangesAsync();

            return employee;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IEnumerable<Employee>?> GetAllAsync(int page = 1, int size = 15, string search = "")
    {
        try
        {
            var employees = await _pastinhaContext.Employees
                .AsNoTracking()
                .Where(w => w.NomFun!.ToLower().Contains(search.ToLower()) ||
                                     w.NumCad.ToString().ToLower().Contains(search.ToLower()))
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync();
            return employees ?? [];
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<Employee?> GetByEmployeeAsync(int numEmp, int tipCol, int numCad)
    {
        try
        {
            var employee = await _pastinhaContext.Employees
                .Where(w => w.NumEmp == numEmp &&
                                w.TipCol == tipCol &&
                                w.NumCad == numCad)
                .SingleOrDefaultAsync();
            return employee;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<Employee?> GetByIdAsync(int id)
    {
        try
        {
            var employee = await _pastinhaContext.Employees
                .Where(w => w.Id == id)
                .SingleOrDefaultAsync();
            return employee;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<Employee?> UpdateAsync(Employee employee)
    {
        try
        {
            if (employee is null)
                return null;

            var employeeCurrent = await GetByIdAsync(employee.Id);
            if (employeeCurrent is null)
                return null;

            _pastinhaContext.Employees.Entry(employeeCurrent).CurrentValues.SetValues(employee);
            await _pastinhaContext.SaveChangesAsync();
            return employee;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
