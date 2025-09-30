using Pastinha.Base.Model.DataFileProcessed;
using Pastinha.Base.Repository.Interface;
using Pastinha.Service.Service.Database.Interface;
using Pastinha.Utility.Utility;

namespace Pastinha.Service.Service.Database;

public class ReturnCountDataFile(IServiceScopeFactory _serviceScopeFactory, CreateLog _createLog) : IReturnCountDataFile
{
    public async Task<CountDataFile?> Create(CountDataFile countDataFile)
    {
        try
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var countDataFileScope = scope.ServiceProvider.GetRequiredService<ICountDataFileRepository>();
            await countDataFileScope.Create(countDataFile);

            return countDataFile;
        }
        catch (Exception ex)
        {
            _createLog.Log($"[ERRO] CreateCountDataFile {ex.Message}");
            return null;
        }

    }

    public async Task<CountDataFile?> GetByDate(DateTime dateTime)
    {
        try
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var _returnCountDataFile = scope.ServiceProvider.GetRequiredService<ICountDataFileRepository>();

            var id = await _returnCountDataFile.GetFromIdDateCurrent();
            var countDataFile = await _returnCountDataFile.GetById(id);

            return countDataFile;
        }
        catch (Exception ex)
        {
            _createLog.Log($"[ERRO] GetByDate {ex.Message}");
            return null;
        }
    }

    public async Task<CountDataFile?> GetById(int id)
    {
        try
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var countDataFileScope = scope.ServiceProvider.GetRequiredService<ICountDataFileRepository>();
            var idCountDataFile = await countDataFileScope.GetById(id);

            return idCountDataFile;
        }
        catch (Exception ex)
        {
            _createLog.Log($"[ERRO] GetById {ex.Message}");
            return null;
        }
    }

    public async Task<int> GetFromIdDateCurrent()
    {
        try
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var countDataFileScope = scope.ServiceProvider.GetRequiredService<ICountDataFileRepository>();
            var id = await countDataFileScope.GetFromIdDateCurrent();

            return id;
        }
        catch (Exception ex)
        {
            _createLog.Log($"[ERRO] GetCountDataFile {ex.Message}");
            return 0;
        }
    }

    public async Task<CountDataFile?> Update(CountDataFile countDataFile)
    {
        try
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var _returnCountDataFile = scope.ServiceProvider.GetRequiredService<ICountDataFileRepository>();
            await _returnCountDataFile.Update(countDataFile);

            return countDataFile;
        }
        catch (Exception ex)
        {
            _createLog.Log($"[ERRO] UpdateCountDataFile {ex.Message}");
            return null;
        }
    }
}
