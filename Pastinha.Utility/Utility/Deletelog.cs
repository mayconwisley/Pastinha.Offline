namespace Pastinha.Utility.Utility;

public static class Deletelog
{
	public static void Delete(bool isDeleteFiles, int days, string pathFilesLogs)
	{
		if (isDeleteFiles)
		{
			var filesDirectory = Directory.GetFiles(pathFilesLogs, "*.zip", SearchOption.TopDirectoryOnly);
			var filesToDelete = filesDirectory
				.Select(f => new FileInfo(f))
				.Where(f => f.LastWriteTime.Date < DateTime.Now.AddDays(-days).Date)
				.ToList();

			foreach (var file in filesToDelete)
				File.Delete(file.FullName);
		}
	}
}
