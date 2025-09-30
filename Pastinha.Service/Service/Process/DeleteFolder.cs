using Pastinha.Service.Service.Process.Interface;
using Pastinha.Utility.Utility;

namespace Pastinha.Service.Service.Process;

public class DeleteFolder(CreateLog _createLog) : IDeleteFolder
{
	public void DeleteFolderProcessed(string[] subDirectories)
	{
		foreach (string directory in subDirectories)
		{
			_createLog.Log($"[INFO] Deletando diretório {directory}, arquivos já incluido na Platform Senior X");

			try
			{
				if (Directory.Exists(directory))
					Directory.Delete(directory, true);
			}
			catch (FileNotFoundException ex)
			{
				_createLog.Log($"Erro ao deletar o diretório {directory}: {ex.Message}");
			}
		}

		if (subDirectories.Length > 0)
			_createLog.Log("[SUCESSO] Diretorios deletados.");
	}
}
