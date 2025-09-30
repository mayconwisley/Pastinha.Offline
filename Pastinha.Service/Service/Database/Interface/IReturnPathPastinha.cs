using Pastinha.Base.Model.Folder;

namespace Pastinha.Service.Service.Database.Interface;

public interface IReturnPathPastinha
{
	Task<FolderPastinhaSenior?> GetPathAsync();
}
