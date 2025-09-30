using Pastinha.Service.Service.Process.Interface;
using Pastinha.Utility.Utility;

namespace Pastinha.Service.Service.Process;

public class MoveFoderError(ICreateFolder _createFolder, CreateLog _createLog) : IMoveFoderError
{
    public bool Mover(string pathError, string path, string nameFolder)
    {
        try
        {
            FileInfo fileInfo = new FileInfo(path);
            string pathErrorNew = Path.Combine(pathError, nameFolder);
            pathErrorNew = _createFolder.Create(pathErrorNew);
            pathErrorNew = Path.Combine(pathErrorNew, fileInfo.Name);

            _createLog.Log($"[AVISO] Nome do Arquivo não encontrado, movendo para: {pathErrorNew}");
            File.Move(fileInfo.FullName, pathErrorNew);
            if (!string.IsNullOrEmpty(fileInfo.FullName))
                File.Delete(fileInfo.FullName);

            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
