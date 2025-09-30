using Pastinha.Base.Model.FileProcessed;

namespace Pastinha.Base.Repository.Interface;

public interface IFileProcessedRepository
{
    Task<IEnumerable<FileProcessed>?> GetAllAsync(int page = 1, int size = 15, string search = "");
    Task<FileProcessed?> GetByIdAsync(int id);
    Task<IEnumerable<FileProcessed>?> GetByEmployeeAsync(int numEmp, int tipCol, int numCad);
    Task<FileProcessed?> CreateAsync(FileProcessed fileProcessed);
    Task<FileProcessed?> UpdateAsync(int id);
    Task<FileProcessed?> DeleteAsync(int id);
}
