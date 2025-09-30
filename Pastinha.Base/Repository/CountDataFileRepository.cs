using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Pastinha.Base.Database;
using Pastinha.Base.Model.DataFileProcessed;
using Pastinha.Base.Repository.Interface;
using System.Data;

namespace Pastinha.Base.Repository;

public class CountDataFileRepository(PastinhaContext _pastinhaContext, IMemoryCache _cache) : ICountDataFileRepository
{
    public async Task<CountDataFile?> Create(CountDataFile countDataFile)
    {
        try
        {
            if (countDataFile is not null)
            {
                _pastinhaContext.CountDataFiles.Add(countDataFile);
                await _pastinhaContext.SaveChangesAsync();

            }
            return countDataFile ?? null;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public async Task<CountDataFile?> Delete(int id)
    {
        try
        {
            if (id < 0)
                return null;

            var countDataFile = await GetById(id);
            if (countDataFile is null)
                return null;

            _pastinhaContext.CountDataFiles.Remove(countDataFile);
            await _pastinhaContext.SaveChangesAsync();
            return countDataFile;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public async Task<IEnumerable<CountDataFile>?> GetAll()
    {
        try
        {
            var countDataFileList = await _pastinhaContext.CountDataFiles
                 .AsNoTracking()
                 .OrderBy(o => o.CountPDF)
                 .ToListAsync();
            return countDataFileList ?? [];
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<DataTable?> GetByDate(DateTime dateInitial, DateTime dateFinal)
    {
        try
        {
            var cacheKey = $"CountDataFile_{dateInitial:yyyyMMdd}_{dateFinal:yyyyMMdd}";

            if (_cache.TryGetValue(cacheKey, out DataTable? cachedData))
                return cachedData;


            var countDataFileList = await _pastinhaContext.CountDataFiles
                .AsNoTracking()
                .Where(w => w.DateProcess.Date >= dateInitial.Date &&
                        w.DateProcess.Date <= dateFinal)
                .OrderByDescending(o => o.DateProcess)
                .ToListAsync();


            var table = new DataTable("CountDataFile");

            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("DateProcess", typeof(DateTime));
            table.Columns.Add("CountPDF", typeof(int));
            table.Columns.Add("CountImage", typeof(int));
            table.Columns.Add("CountOtherFormat", typeof(int));
            table.Columns.Add("CountSendPlatform", typeof(int));

            foreach (var item in countDataFileList)
            {
                table.Rows.Add(
                    item.Id,
                    item.DateProcess,
                    item.CountPDF,
                    item.CountImage,
                    item.CountOtherFormat,
                    item.CountSendPlatform
                );
            }
            _cache.Set(cacheKey, countDataFileList, TimeSpan.FromMinutes(5));

            return table;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<CountDataFile?> GetById(int id)
    {
        try
        {
            var countDataFile = await _pastinhaContext.CountDataFiles
                .Where(w => w.Id == id)
                .FirstOrDefaultAsync();
            return countDataFile ?? null;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<int> GetFromIdDateCurrent()
    {
        try
        {
            var id = await _pastinhaContext.CountDataFiles
                 .AsNoTracking()
                 .Where(w => w.DateProcess == DateTime.Now.Date)
                 .Select(w => w.Id)
                 .FirstOrDefaultAsync();

            return id;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<CountDataFile?> Update(CountDataFile countDataFile)
    {
        try
        {
            var countDataFile1 = await GetById(countDataFile.Id);
            if (countDataFile1 is null)
                return null;

            _pastinhaContext.CountDataFiles.Entry(countDataFile1).CurrentValues.SetValues(countDataFile);
            await _pastinhaContext.SaveChangesAsync();

            return countDataFile;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
