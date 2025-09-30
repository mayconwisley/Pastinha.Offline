using Pastinha.Base.Model.Folder;

namespace Pastinha.Base.Repository.Interface;

public interface IFolderOfflineRepository
{
	Task<IEnumerable<FolderOfflinePastinhaSenior>> GetAll(int page = 1, int size = 15, string search = "");
	Task<FolderOfflinePastinhaSenior?> GetFirstAsync();
	Task<FolderOfflinePastinhaSenior> GetByName(string name);
	Task<FolderOfflinePastinhaSenior> GetById(int id);
	Task<FolderOfflinePastinhaSenior> Create(FolderOfflinePastinhaSenior folderOfflinePastinhaSenior);
	Task<FolderOfflinePastinhaSenior> Update(FolderOfflinePastinhaSenior folderOfflinePastinhaSenior);
	Task<FolderOfflinePastinhaSenior> Delete(int id);
}
