using Pastinha.Base.Model.Folder;

namespace Pastinha.Base.Repository.Interface;

public interface IFolderPastinhaRepository
{
	Task<IEnumerable<FolderPastinhaSenior>> GetAll(int page = 1, int size = 15, string search = "");
	Task<FolderPastinhaSenior?> GetFirstAsync();
	Task<FolderPastinhaSenior> GetByName(string name);
	Task<FolderPastinhaSenior> GetById(int id);
	Task<FolderPastinhaSenior> Create(FolderPastinhaSenior folderPastinha);
	Task<FolderPastinhaSenior> Update(FolderPastinhaSenior folderPastinha);
	Task<FolderPastinhaSenior> Delete(int id);
}
