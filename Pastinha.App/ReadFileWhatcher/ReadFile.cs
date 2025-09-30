using Pastinha.Base.Repository.Interface;
using System.Text;

namespace Pastinha.App.ReadFileWhatcher;

public class ReadFile(IFolderPastinhaRepository _folderPastinha)
{
    private readonly StringBuilder stringBuilder = new();

    public async Task<string> ReadRecentFileAsync()
    {
        var path = await _folderPastinha.GetAll();
        var pathLog = path.Select(s => s.PathLog).FirstOrDefault() ?? throw new Exception("Sem definição de caminho de Log");

        string[] files = Directory.GetFiles(pathLog, "*.log", SearchOption.TopDirectoryOnly);
        if (files.Length == 0)
        {
            throw new FileNotFoundException("Nenhum arquivo encontrado no diretório.");
        }

        var recentFile = files
                        .Select(s => new FileInfo(s))
                        .OrderByDescending(o => o.LastWriteTime)
                        .First();

        string[] lines = await File.ReadAllLinesAsync(recentFile.FullName);
        foreach (var line in lines)
        {
            stringBuilder.AppendLine(line);
        }

        FileSystemWatcher fileSystemWatcher = new()
        {
            Path = Path.GetDirectoryName(recentFile.FullName)!,
            Filter = Path.GetFileName(recentFile.FullName),
            NotifyFilter = NotifyFilters.LastWrite
        };

        fileSystemWatcher.Changed += OnChanged;
        fileSystemWatcher.EnableRaisingEvents = true;

        return stringBuilder.ToString();
    }

    private void OnChanged(object sender, FileSystemEventArgs e)
    {
        Thread.Sleep(1000);

        try
        {
            string[] lines = File.ReadAllLines(e.FullPath);
            foreach (var line in lines)
            {
                stringBuilder.AppendLine(line);
            }
        }
        catch (IOException ex)
        {
            throw new IOException($"Erro na leitura do arquivo: {ex.Message}");
        }
    }
}
