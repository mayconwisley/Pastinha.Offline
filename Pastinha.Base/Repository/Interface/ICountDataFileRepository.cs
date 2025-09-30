using Pastinha.Base.Model.DataFileProcessed;
using System.Data;

namespace Pastinha.Base.Repository.Interface;

public interface ICountDataFileRepository
{
    public Task<IEnumerable<CountDataFile>?> GetAll();
    public Task<DataTable?> GetByDate(DateTime dateInitial, DateTime dateFinal);
    public Task<int> GetFromIdDateCurrent();
    public Task<CountDataFile?> GetById(int id);
    public Task<CountDataFile?> Create(CountDataFile countDataFile);
    public Task<CountDataFile?> Update(CountDataFile countDataFile);
    public Task<CountDataFile?> Delete(int id);
}
