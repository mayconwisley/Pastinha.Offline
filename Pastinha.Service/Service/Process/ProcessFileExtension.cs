using Pastinha.Service.Service.Process.Interface;
using Pastinha.Utility.Utility;

namespace Pastinha.Service.Service.Process;

public class ProcessFileExtension(ICreateFolderLoose _createFolderLoose, IMoveFoderError _moveFoderError, CreateLog _createLog) : IProcessFileExtension
{
    public void Process(string file, string pathOutput, string pathError)
    {
        FileInfo fileInfo = new(file);

        _createLog.Log($"[INFO] Verificando nome do arquivo: {fileInfo.Name}");
        if (_createFolderLoose.Create(fileInfo.FullName, pathOutput))
            return;

        _moveFoderError.Mover(pathError, fileInfo.FullName, "Erro Leitura Nome Arquivo");
        _createLog.Log($"[AVISO] Nome no Arquivo não encontrado, movendo para: {pathError}");

        return;
    }
}
