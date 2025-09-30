using Pastinha.Base.Model.FileProcessed;
using Pastinha.Service.Service.Database.Interface;
using Pastinha.Service.Service.Process.Interface;
using Pastinha.Utility.Utility;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace Pastinha.Service.Service.Process;

public class OrganizeFile(ICreateFolder _createFolder, IImageToPdf _imageToPdf, IServiceScopeFactory _serviceScopeFactory,
    ICountFile _countFile, ICreateUpdateFileProcessed _createUpdateFileProcessed, CreateLog _createLog) : IOrganizeFile
{
    // Dicionário para aplicar lock por caminho de arquivo
    private static readonly ConcurrentDictionary<string, object> _fileLocks = new();
    private void CreateFolder(FileInfo fileInfo)
    {
        ReadOnlySpan<char> fileNameSpan = fileInfo.Name.AsSpan();
        string pathOutput;
        string fileName = string.Empty;
        string directory = fileInfo.Directory!.ToString();
        int positionUnderscore = fileNameSpan.IndexOf('_');
        if (positionUnderscore >= 0)
            fileName = fileNameSpan[..positionUnderscore].ToString().Trim();

        //Condição para não criar subpastas infinitamente.
        string newDirectory;
        if (!string.IsNullOrEmpty(fileName))
        {
            if (directory.Contains(fileName))
                directory = directory.Replace(fileName, "");

            newDirectory = _createFolder.Create(Path.Combine(directory, fileName));
            _createLog.Log($"[INFO] Nome novo diretório: {fileName}");
        }
        else
        {
            _createLog.Log($"[INFO] Criando diretório para arquivos avulsos");
            if (directory.Contains("Arquivos Avulsos"))
                directory = directory.Replace("Arquivos Avulsos", "");

            newDirectory = _createFolder.Create(Path.Combine(directory, "Arquivos Avulsos"));
            _createLog.Log($"[INFO] Nome novo diretório: {newDirectory}");
        }

        pathOutput = Path.Combine(newDirectory, fileInfo.Name);
        CreateFile(fileInfo, pathOutput);
    }

    private void CreateFile(FileInfo fileInfo, string pathOutput)
    {
        // Bloqueia por caminho completo do arquivo original
        var fileLock = _fileLocks.GetOrAdd(fileInfo.FullName, _ => new object());

        lock (fileLock)
        {
            try
            {
                if (!File.Exists(fileInfo.FullName))
                {
                    _createLog.Log($"[AVISO] Arquivo não existe: {fileInfo.FullName}");
                    return;
                }

                if (File.Exists(pathOutput))
                {
                    _createLog.Log($"[AVISO] Arquivo destino já existe: {pathOutput}");
                    return;
                }
                _createLog.Log($"[INFO] Movendo arquivo: {pathOutput}");
                File.Move(fileInfo.FullName, pathOutput);

            }
            catch (FileNotFoundException)
            {
                _createLog.Log($"[AVISO] Arquivo não encontrado para mover: {fileInfo.FullName}");
            }
            catch (IOException ioEx)
            {
                _createLog.Log($"[ERRO] Arquivo já pode ter sido movido ou em uso: {ioEx.Message}");
            }
            catch (Exception ex)
            {
                _createLog.Log($"[ERRO] Erro inesperado ao mover arquivo: {ex.Message}");
            }
            finally
            {
                _fileLocks.TryRemove(fileInfo.FullName, out _);
            }
        }
    }

    private async Task CreatePdfAsync(string directory)
    {
        var subDirectories = Directory.GetDirectories(directory);
        var nameFolder = NameFolder.GetName(directory);

        foreach (var strDirectory in subDirectories)
        {
            DirectoryInfo directoryInfo = new(strDirectory);

            if (directoryInfo.FullName.Contains("Arquivos Avulsos"))
                continue;
            try
            {
                _createLog.Log($"[INFO] Criando arquivo PDF: {strDirectory}");
                var files = directoryInfo.GetFiles("*.png")
                           .OrderBy(o => o.Name)
                           .ToList();

                if (files.Count == 0)
                    continue;

                string fileNameFull = files.First().Name;
                string fileNameOutput = NameFilePdf(fileNameFull);
                string[] imageFile = [.. files.Select(f => f.FullName)];
                string pathOutputFolder = directoryInfo.FullName;
                string pathCombine = Path.Combine(pathOutputFolder, $"{fileNameOutput}.pdf");

                var fileLock = _fileLocks.GetOrAdd(pathCombine, _ => new object());

                lock (fileLock)
                {
                    _imageToPdf.Process(imageFile, pathCombine);
                }

                _fileLocks.TryRemove(pathCombine, out _);
                _createLog.Log($"[SUCESSO] Processo Concluído");
                //await CreateFileProcessed(nameFolder, fileName[0].Trim());

                foreach (var item in files)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        try
                        {
                            _createLog.Log($"[INFO] Deletando arquivos .png {item}");
                            File.Delete(item.FullName);
                            break;
                        }
                        catch (IOException)
                        {
                            await Task.Delay(500);
                        }
                        catch (Exception ex)
                        {
                            _createLog.Log($"[ERRO] Falha ao deletar {item.FullName}: {ex.Message}");
                            break;
                        }
                    }
                }
                _createLog.Log($"[SUCESSO] Arquivos .PNG deletado com sucesso");
            }
            catch (Exception ex)
            {
                _createLog.Log($"[ERRO] Falha ao criar PDF no diretório {strDirectory}: {ex.Message}");
            }
        }
    }

    private string NameFilePdf(string fileNameFull)
    {
        ReadOnlySpan<char> fileNameSpan = fileNameFull.AsSpan();

        int positionSeparator = fileNameSpan.IndexOf(" - ");

        string fileNameOutput = positionSeparator != -1
            ? fileNameSpan[..positionSeparator].ToString().Trim()
            : fileNameSpan.ToString().Trim();

        return fileNameOutput;
    }

    private async Task CreateFileProcessed(string nameFolder, string nomDoc)
    {
        try
        {
            DateOnly dateProcessed = DateOnly.FromDateTime(DateTime.Now);
            var fileProcessed = NameFolderFile(nameFolder, nomDoc, dateProcessed);

            await _createUpdateFileProcessed.CreateUpdateAsync(fileProcessed);
        }
        catch (Exception ex)
        {
            _createLog.Log($"[ERRO] {ex.Message}");
        }
    }

    private FileProcessed NameFolderFile(string nameFolder, string nomDoc, DateOnly dateProcessed)
    {
        ReadOnlySpan<char> nameFolderSpan = nameFolder.AsSpan();
        int positionSeparator = nameFolderSpan.IndexOf("-");

        int numEmp = int.Parse(nameFolderSpan[..positionSeparator]);

        ReadOnlySpan<char> nameFolderSpanRemaining = nameFolderSpan[(positionSeparator + 1)..];
        positionSeparator = nameFolderSpanRemaining.IndexOf("-");
        int tipCol = int.Parse(nameFolderSpanRemaining[..positionSeparator]);

        nameFolderSpanRemaining = nameFolderSpanRemaining[(positionSeparator + 1)..];
        positionSeparator = nameFolderSpanRemaining.IndexOf("-");
        int numCad = int.Parse(nameFolderSpanRemaining[..positionSeparator]);

        return new FileProcessed(numEmp, tipCol, numCad, 1, nomDoc, dateProcessed);
    }

    public async Task Organize(string pathOutput)
    {

        if (!Directory.Exists(pathOutput))
        {
            _createLog.Log($"[ERRO] Diretório não encontrado: {pathOutput}");
            return;
        }

        //Equilibrado para a maioria dos cenários e evita sobrecarregar o servidor.
        int maxParallelism = Math.Max(2, Environment.ProcessorCount / 2);

        var stopwatch = Stopwatch.StartNew();
        using var scope = _serviceScopeFactory.CreateScope();
        var _returnStatusFired = scope.ServiceProvider.GetRequiredService<IReturnStatusFired>();
        var statusFired = await _returnStatusFired.GetStatusFiredAsync();
        var isStatusFired = statusFired.Any();

        var paths = Directory.GetDirectories(pathOutput, "*.*", SearchOption.TopDirectoryOnly);

        _createLog.Log($"[INFO][ORGANIZAÇÃO] Início do processamento - {DateTime.Now:HH:mm:ss}.");

        await Parallel.ForEachAsync(paths, new ParallelOptions { MaxDegreeOfParallelism = maxParallelism }, async (path, cancellationToken) =>
        {
            try
            {
                string[] subDirectories = isStatusFired
                    ? Directory.GetDirectories(path, "*.*", SearchOption.TopDirectoryOnly)
                    : Directory.GetDirectories(pathOutput, "*.*", SearchOption.TopDirectoryOnly);

                await Parallel.ForEachAsync(subDirectories, async (subDirectory, cancellationTokenSub) =>
                {
                    try
                    {
                        string[] files = Directory.GetFiles(subDirectory, "*.*", SearchOption.TopDirectoryOnly);

                        if (files.Length == 0)
                        {
                            _createLog.Log($"[AVISO] Diretório já organizado: {subDirectory}");
                            return;
                        }

                        await Parallel.ForEachAsync(files, async (file, _) =>
                        {
                            try
                            {
                                _createLog.Log($"[INFO] Processando arquivo {file}");
                                FileInfo fileInfo = new(file);
                                CreateFolder(fileInfo);
                            }
                            catch (Exception ex)
                            {
                                _createLog.Log($"[ERRO] Organização de arquivos {file}: {ex.Message}");
                            }
                            await Task.CompletedTask;
                        });

                        await CreatePdfAsync(subDirectory);
                    }
                    catch (Exception ex)
                    {
                        _createLog.Log($"[ERRO] Diretório {subDirectory}: {ex.Message}");
                    }
                });
            }
            catch (Exception ex)
            {
                _createLog.Log($"[ERRO] Caminho {path}: {ex.Message}");
            }
        });
        await _countFile.CountFileFolder(pathOutput);

        stopwatch.Stop();
        _createLog.Log($"[INFO][ORGANIZAÇÃO] Fim do processamento - {DateTime.Now:HH:mm:ss}, Tempo total: {stopwatch.Elapsed}");
    }
}
