using Pastinha.Service.Service.Process.Interface;
using Pastinha.Utility.Utility;
using System.Diagnostics;

namespace Pastinha.Service.Service.Process;

public class ProcessOffline(ICreateFolder _createFolder, IMoveFolder _moveFolder, CreateLog _createLog) : IProcessOffline
{
	public void Process(string pathOutput, string pathOffline)
	{
		var stopwatch = Stopwatch.StartNew();
		_createLog.Log($"[INFO][OFFLINE] Inicio do processamento - {DateTime.Now:HH:mm:ss}.");
		_createLog.Log($"[INFO] Processando diretório offline: {pathOffline}");
		string[] folders = Directory.GetDirectories(pathOutput, "*.*", SearchOption.TopDirectoryOnly);
		string newPathOffilineActive;
		if (folders.Length == 0)
		{
			_createLog.Log($"[INFO] Nenhum documento encontrado {pathOffline}");
			return;
		}

		foreach (string folder in folders)
		{
			_createLog.Log($"[INFO] Processando diretório de saida: {folder}");
			DirectoryInfo directoryInfo = new(folder);

			var newPathOffline = Path.Combine(pathOffline, directoryInfo.Name);
			_createLog.Log($"[INFO] Montando diretório offline: {newPathOffline}");

			string[] folderOutputs = Directory.GetDirectories(folder, "*.*", SearchOption.TopDirectoryOnly);

			foreach (var folderOutput in folderOutputs)
			{
				_createLog.Log($"[INFO] Processando diretório de saida {folderOutput}");

				DirectoryInfo directoryInfo1 = new(folderOutput);

				newPathOffilineActive = Path.Combine(pathOffline, directoryInfo1.Parent!.Name, directoryInfo1.Name);

				_createFolder.Create(newPathOffline);

				if (!_moveFolder.Move(folderOutput, newPathOffilineActive))
				{
					var newPathOffline1 = Path.Combine(newPathOffline, directoryInfo1.Name);
					_moveFolder.Move(newPathOffilineActive, newPathOffline1);
					if (!Directory.Exists(folderOutput))
						continue;

					string[] files1 = Directory.GetFiles(folderOutput, "*.*", SearchOption.AllDirectories);

					if (files1.Length == 0)
					{
						_createLog.Log($"[INFO] Nenhum arquivos no diretório: {folder}");
						_createLog.Log($"[INFO] Excluido diretório já processado: {folder}");
						Directory.Delete(folder, true);
						return;
					}

					foreach (var file in files1)
					{
						_createLog.Log($"[INFO] Verificando arquivo {file}");
						FileInfo fileInfo = new(file);
						string pathNewFile;
						if (file.Contains("\\Ativos") || file.Contains("\\Demitidos"))
							pathNewFile = Path.Combine(newPathOffline, directoryInfo1.Name, fileInfo.Directory!.Name, fileInfo.Name);
						else
							pathNewFile = Path.Combine(newPathOffline, directoryInfo1.Name, fileInfo.Name);

						FileInfo fileInfo1 = new(pathNewFile);

						_createLog.Log($"[INFO] Novo arquivo {pathNewFile}");

						if (!Directory.Exists(fileInfo1.DirectoryName))
						{
							_createLog.Log($"[INFO] Criando novo diretório para o arquivo {pathNewFile}");
							Directory.Move(fileInfo.DirectoryName!, fileInfo1.DirectoryName!);
							continue;
						}

						if (!File.Exists(pathNewFile))
						{
							_createLog.Log($"[INFO] Movendo arquivo {pathNewFile}");
							File.Move(fileInfo.FullName, pathNewFile);
						}
						else
						{
							pathNewFile = pathNewFile.Replace(fileInfo.Extension, $"_{Guid.NewGuid():N}{fileInfo.Extension}");
							_createLog.Log($"[INFO] Já existe um arquivo com o mesmo nome, renomeando {pathNewFile}");

							File.Move(fileInfo.FullName, pathNewFile);
						}
					}
					_createLog.Log($"[INFO] Excluido diretório já processado {folderOutput}");
					Directory.Delete(folderOutput, true);
				}
			}
			_createLog.Log($"[INFO] Excluido diretório já processado {folder}");
			Directory.Delete(folder, true);

		}
		_createLog.Log($"[INFO][OFFLINE] Término do processamento - {DateTime.Now:HH:mm:ss}, Tempo total de processamento: {stopwatch.Elapsed}");
		return;
	}
}
