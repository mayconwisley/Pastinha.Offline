using Pastinha.Model.Model;
using Pastinha.Service.Service.Process.Interface;
using Pastinha.Utility.Utility;

namespace Pastinha.Service.Service.Process;

public class RenameFile(CreateLog _createLog) : IRenameFile
{
    public void Rename(DataQrCode dataQrCode, string pathOutputImage, string pathOutput)
    {
        string nameDoc = dataQrCode.NomDoc!;
        if (ContainsAccents.Contain(dataQrCode.NomDoc!))
        {
            nameDoc = RemoveAccents.Remover(dataQrCode.NomDoc!);
        }

        string nameFile = $"{nameDoc}_{dataQrCode.NumEmp:0000}-{dataQrCode.TipCol:00}-{dataQrCode.NumCad:00000000} - Pagina {dataQrCode.NumPag:00000}.png";
        _createLog.Log($"[INFO] Renomeando arquivo");
        string outputPathRename = Path.Combine(pathOutput, nameFile);
        _createLog.Log($"[INFO] Novo nome do arquivo: {nameFile}");
        _createLog.Log($"[INFO] Movendo o arquivo para: {outputPathRename}");

        if (!File.Exists(outputPathRename))
        {
            File.Move(pathOutputImage, outputPathRename);
        }
        else
        {
            _createLog.Log($"[INFO] Foi encontrado um arquivo com o mesmo nome. Substituindo para o arquivo atual: {outputPathRename}");
            File.Delete(outputPathRename);
            File.Move(pathOutputImage, outputPathRename);
        }
    }

    public void Rename(string pathOutputImage, string pathOutput)
    {
        _createLog.Log($"[INFO] Renomeando arquivo sem QRCode");
        _createLog.Log($"[INFO] Movendo o arquivo para: {pathOutput}");
        if (!File.Exists(pathOutput))
        {
            File.Move(pathOutputImage, pathOutput);
        }
        else
        {
            File.Delete(pathOutput);
            File.Move(pathOutputImage, pathOutput);
        }
    }
}
