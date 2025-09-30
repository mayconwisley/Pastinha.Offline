using System.IO.Compression;

namespace Pastinha.Utility.Utility;

public static class CompactLog
{
	public static void Compact(string pathLog)
	{
		DateTime previousMonth = DateTime.Now.AddMonths(-1);
		string zipPath = Path.Combine(pathLog, $"{DateTime.Now.AddMonths(-1):yyyy-MM} Logs Competencia.zip");
		var allFiles = Directory.GetFiles(pathLog, "*.log", SearchOption.TopDirectoryOnly);

		var filesToCompact = allFiles
			.Select(f => new FileInfo(f))
			.Where(f => f.LastWriteTime.Month == previousMonth.Month && f.LastWriteTime.Year == previousMonth.Year)
			.ToList();
		if (filesToCompact.Count == 0)
			return;

		using FileStream fileStream = new(zipPath, FileMode.Create);
		using ZipArchive archive = new(fileStream, ZipArchiveMode.Create);

		foreach (var file in filesToCompact)
		{
			archive.CreateEntryFromFile(file.FullName, file.Name);
			try
			{
				File.Delete(file.FullName);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Erro ao excluir o arquivo {file}: {ex.Message}");
			}
		}
	}
}

