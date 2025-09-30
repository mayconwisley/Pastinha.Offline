using Pastinha.Base.Repository.Interface;

namespace Pastinha.App.ReadPathFolder;

public class ReadPath(IFolderPastinhaRepository _folderPastinha)
{
    public async Task<bool> IsFolderCreated()
    {
        var isFolder = await _folderPastinha.GetAll();
        return isFolder.Any();

    }
}
