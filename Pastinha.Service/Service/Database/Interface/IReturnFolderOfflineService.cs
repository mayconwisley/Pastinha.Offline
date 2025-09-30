using Pastinha.Base.Model.Folder;

namespace Pastinha.Service.Service.Database.Interface;

public interface IReturnFolderOfflineService
{
	Task<FolderOfflinePastinhaSenior?> GetFolderOffline();
}
