using Pastinha.Service.Service.Process.Interface;

namespace Pastinha.Service.Service.Process;

public class CreateFolderLoose(IRenameFile _renameFile, ICreateFolder _createFolder) : ICreateFolderLoose
{
    public bool Create(string file, string nameFile, string pathOutput)
    {
        string pathFolder = _createFolder.Create(nameFile, pathOutput);
        if (!string.IsNullOrEmpty(pathFolder))
        {
            string newPathOutput = Path.Combine(pathFolder, nameFile);
            _renameFile.Rename(file, newPathOutput);
            return true;
        }
        return false;
    }

    public bool Create(string nameFile, string pathOutput)
    {
        FileInfo fileInfo = new(nameFile);
        string pathFolder = _createFolder.Create(fileInfo.Name, pathOutput);
        if (!string.IsNullOrEmpty(pathFolder))
        {
            string newPathOutput = Path.Combine(pathFolder, fileInfo.Name);
            _renameFile.Rename(fileInfo.FullName, newPathOutput);
            return true;
        }
        return false;
    }
}
