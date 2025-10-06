using Pastinha.Service.Service.Process.Interface;
using Pastinha.Utility.Utility;

namespace Pastinha.Service.Service.Process;

public class ProcessFileImage(IProcessQrCodeImage _processQrCodeImage, ICreateFolder _createFolder,
	IRenameFile _renameFile, CreateLog _createLog) : IProcessFileImage
{
	public async Task Process(string file, string pathOutput, string pathError)
	{
		try
		{
			var resizeAttempts = GenerateResizeAttempts.Generate();

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
			_createLog.Log($"[INFO][.PNG .JPG . JPEG .BMP] Término do processo da imagem (.PNG .JPG . JPEG .BMP)");
		}
		catch (Exception ex)
		{
			_createLog.Log($"[ERRO] Erro ao mover arquivo: {ex.Message}");
		}
	}
}
