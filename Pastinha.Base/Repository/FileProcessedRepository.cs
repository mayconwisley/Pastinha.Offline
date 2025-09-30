using Microsoft.EntityFrameworkCore;
using Pastinha.Base.Database;
using Pastinha.Base.Model.FileProcessed;
using Pastinha.Base.Repository.Interface;
using System.Collections.Concurrent;

namespace Pastinha.Base.Repository;

public class FileProcessedRepository(PastinhaContext _pastinhaContext) : IFileProcessedRepository
{
    // Dicionário de locks por Id (thread-safe)
    private static readonly ConcurrentDictionary<int, SemaphoreSlim> _locks = new();

    public async Task<FileProcessed?> CreateAsync(FileProcessed fileProcessed)
    {
        try
        {
            if (fileProcessed is null)
                return null;

            _pastinhaContext.FileProcesseds.Add(fileProcessed);
            await _pastinhaContext.SaveChangesAsync();
            return fileProcessed;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<FileProcessed?> DeleteAsync(int id)
    {
        try
        {
            if (id <= 0)
                return null;

            var fileProcessed = await GetByIdAsync(id);
            if (fileProcessed is null)
                return null;

            _pastinhaContext.FileProcesseds.Remove(fileProcessed);
            await _pastinhaContext.SaveChangesAsync();
            return fileProcessed;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IEnumerable<FileProcessed>?> GetAllAsync(int page = 1, int size = 15, string search = "")
    {
        try
        {
            var fileProcesseds = await _pastinhaContext.FileProcesseds
                .AsNoTracking()
                .Where(w => w.NomDoc.ToLower().Contains(search.ToLower()) ||
                                     w.NumCad.ToString().ToLower().Contains(search.ToLower()))
                .OrderBy(o => o.NomDoc)
                .ToListAsync();
            return fileProcesseds ?? [];
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IEnumerable<FileProcessed>?> GetByEmployeeAsync(int numEmp, int tipCol, int numCad)
    {
        try
        {
            var fileProcesseds = await _pastinhaContext.FileProcesseds
                .AsNoTracking()
                .Where(w => w.NumEmp == numEmp &&
                                     w.TipCol == tipCol &&
                                     w.NumCad == numCad)
                .OrderBy(o => o.NomDoc)
                .ToListAsync();
            return fileProcesseds ?? [];
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<FileProcessed?> GetByIdAsync(int id)
    {
        try
        {
            var fileProcessed = await _pastinhaContext.FileProcesseds
                .Where(w => w.Id == id)
                .FirstOrDefaultAsync();

            return fileProcessed;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<FileProcessed?> UpdateAsync(int id)
    {
        try
        {


            // Obtém ou cria um lock para o Id
            var myLock = _locks.GetOrAdd(id, _ => new SemaphoreSlim(1, 1));

            await myLock.WaitAsync();

            try
            {
                var fileProcessedCurrent = await GetByIdAsync(id);
                if (fileProcessedCurrent is null)
                    return null;

                fileProcessedCurrent.SetAmount(1);
                _pastinhaContext.Entry(fileProcessedCurrent).Property(p => p.AmountProcessed).IsModified = true;
                await _pastinhaContext.SaveChangesAsync();

                return fileProcessedCurrent;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                myLock.Release();

                // Se ninguém mais estiver esperando no SemaphoreSlim, podemos removê-lo do dicionário
                if (myLock.CurrentCount == 1)
                {
                    _locks.TryRemove(id, out _);
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}
