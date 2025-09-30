using Pastinha.Base.Model.FileProcessed;

namespace Pastinha.Service.Service.Database.Interface;

public interface ICreateUpdateFileProcessed
{
	Task CreateUpdateAsync(FileProcessed fileProcessed);
}
