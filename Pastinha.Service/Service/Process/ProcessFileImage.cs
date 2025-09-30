using Pastinha.Service.Service.Process.Interface;
using Pastinha.Utility.Utility;

namespace Pastinha.Service.Service.Process;

public class ProcessFileImage(IProcessQrCodeImage _processQrCodeImage, ICreateFolder _createFolder,
    IRenameFile _renameFile, ICreateFolderLoose _createFolderLoose, CreateLog _createLog) : IProcessFileImage
{
    public async Task Process(string file, string pathOutput, string pathError, List<(int dpi, int width, int height)> resizeAttempts)
    {
        try
        {
            _createLog.Log($"[INFO][.PNG .JPG . JPEG .BMP] Inicio do processo da imagem (.PNG .JPG . JPEG .BMP)");
            string nameFile = Path.GetFileName(file);

            FileInfo fileInfo = new(file);
            string pathOutputImage = Path.Combine(pathOutput, $"{fileInfo.Name}");
            if (string.IsNullOrEmpty(file))
            {
                _createLog.Log($"[INFO] caminho do arquivo vazio");
                return;
            }

            File.Move(file, pathOutputImage);

            var dataQrCode = await _processQrCodeImage.ProcessSingleQrCodeMemory(pathOutputImage, pathError, resizeAttempts);

            if (dataQrCode is not null)
            {
                string newPathOutput = await _createFolder.Create(dataQrCode, pathOutput);
                _renameFile.Rename(dataQrCode, pathOutputImage, newPathOutput);
            }
            else
            {
                _createLog.Log($"[INFO] Verificando nome do arquivo: {pathOutputImage}");
                _createFolderLoose.Create(file, pathOutputImage, pathOutput);
            }

            _createLog.Log($"[INFO][.PNG .JPG . JPEG .BMP] Término do processo da imagem (.PNG .JPG . JPEG .BMP)");
        }
        catch (Exception ex)
        {
            _createLog.Log($"[ERRO] Erro ao mover arquivo: {ex.Message}");
        }
    }
}
