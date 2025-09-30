using Pastinha.Service.Service.Database.Interface;
using Pastinha.Service.Service.Process.Interface;
using Pastinha.Utility.Utility;

namespace Pastinha.Service;

public class Worker(ILogger<Worker> _logger, IProcessFile _processFile, IOrganizeFile _organizeFile,
    IProcessOffline _processOffline, IServiceScopeFactory _serviceScopeFactory, CreateLog _createLog) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var scope = _serviceScopeFactory.CreateScope();
        var _returnPathPastinha = scope.ServiceProvider.GetRequiredService<IReturnPathPastinha>();
        var _returnFolderOfflineService = scope.ServiceProvider.GetRequiredService<IReturnFolderOfflineService>();

        var pathPastinha = await _returnPathPastinha.GetPathAsync();
        if (pathPastinha is null)
        {
            _createLog.Log($"[INFO] Definição de Pastas não criado.");
            return;
        }
        _createLog.PathLog(pathPastinha.PathLog!);
        _createLog.Log($"[INFO] Serviço Pastinha.exe iniciado");

        var pathOffline = await _returnFolderOfflineService.GetFolderOffline();
        var resizeAttempts = GenerateResizeAttempts.Generate();

        while (!stoppingToken.IsCancellationRequested)
        {
            CompactLog.Compact(pathPastinha.PathLog!);
            Deletelog.Delete(pathPastinha.IsDelete, pathPastinha.DaysDelete, pathPastinha.PathLog!);

            if (string.IsNullOrEmpty(pathPastinha.PathInput) || string.IsNullOrEmpty(pathPastinha.PathOutput) || string.IsNullOrEmpty(pathPastinha.PathError))
            {
                _createLog.Log($"[AVISO] Diretórios não encontrado.");
                continue;
            }
            else
            {
                await _processFile.Process(pathPastinha.PathInput, pathPastinha.PathOutput, pathPastinha.PathError, resizeAttempts);
            }

            if (Directory.GetDirectories(pathPastinha.PathOutput!).Length != 0)
            {
                _createLog.Log($"[INFO] Organizando arquivos: {pathPastinha.PathOutput}");
                await _organizeFile.Organize(pathPastinha.PathOutput!);

                if (pathOffline?.IsOffline == true)
                {
                    _createLog.Log($"[INFO] Configuração Offline Ativa");
                    _processOffline.Process(pathPastinha.PathOutput!, pathOffline.PathOffline!);
                    continue;
                }
                _createLog.Log($"[INFO] Tentando realizar login na Platform Senior X");
            }
            else
            {
                var files = Directory.GetFiles(pathPastinha.PathOutput);
                foreach (var file in files)
                {
                    File.Delete(file);
                }
            }

            if (_logger.IsEnabled(LogLevel.Information))
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

            await Task.Delay(1000, stoppingToken);
        }
    }
}
