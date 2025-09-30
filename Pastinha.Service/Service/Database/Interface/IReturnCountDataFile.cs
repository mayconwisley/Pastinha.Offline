using Pastinha.Base.Model.DataFileProcessed;

namespace Pastinha.Service.Service.Database.Interface;

public interface IReturnCountDataFile
{
    Task<int> GetFromIdDateCurrent();
    Task<CountDataFile?> GetByDate(DateTime dateTime);
    Task<CountDataFile?> GetById(int id);
    Task<CountDataFile?> Create(CountDataFile countDataFile);
    Task<CountDataFile?> Update(CountDataFile countDataFile);
}
