using Pastinha.Service.Service.Process.Interface;
using Pastinha.Utility.Utility;

namespace Pastinha.Service.Service.Process;

public class ProcessFile(IProcessFilePdf _processFilePdf, IProcessFileImage _processFileImage,
    IProcessFileExtension _processFileExtension, CreateLog _createLog) : IProcessFile
{
    // Função assíncrona que processa cada arquivo
    private async Task ProcessFileAsync(string file, string pathOutput, string pathError, List<(int dpi, int width, int height)> resizeAttempts)
    {
        string _file = file;

        if (!File.Exists(file))
        {
            _createLog.Log("[ERRO] Arquivo não informado");
            return;
        }

        if (!Path.Exists(pathOutput))
        {
            _createLog.Log("[ERRO] Caminho da pasta de saida não informado");
            return;
        }

        if (!Path.Exists(pathError))
        {
            _createLog.Log("[ERRO] Caminho da pasta de erros não informado!");
            return;
        }

        _createLog.Log($"[INFO] Processando arquivo : {_file}");

        if (ContainsAccents.Contain(_file))
        {
            try
            {
                _createLog.Log($"[INFO] Renomeando arquivo {_file}");
                string newFileName = RemoveAccents.Remover(_file);

                await Task.Run(() => File.Move(_file, newFileName))
                                .ConfigureAwait(false);

                _file = newFileName;
                _createLog.Log($"[INFO] Novo nome do arquivo {_file}");
            }
            catch (Exception ex)
            {
                _createLog.Log($"[ERRO] Erro ao mover arquivo: {ex.Message}");
                return;
            }
        }

        string extension = Path.GetExtension(_file).ToLower();
        string nameFile = Path.GetFileName(_file);

        if (extension == ".pdf")
        {
            await _processFilePdf.Process(_file, pathOutput, pathError, resizeAttempts);
        }
        else if (extension == ".png" || extension == ".jpg" || extension == ".jpeg" || extension == ".bmp")
        {
            await _processFileImage.Process(_file, pathOutput, pathError, resizeAttempts);
        }
        else
        {
            _createLog.Log($"[INFO][OUTRAS EXTENSÕES] Iniciando processo do arquivo de outras extensões");
            _createLog.Log($"[INFO] Criando diretório avulsa para o arquivo: {nameFile}");
            _processFileExtension.Process(_file, pathOutput, pathError);
            _createLog.Log($"[INFO][OUTRAS EXTENSÕES] Término do processo do arquivo de outras extensões");
        }
    }

    private void DeleteFile(string file)
    {
        try
        {
            if (File.Exists(file))
            {
                _createLog.Log($"[INFO] Deletando arquivo após processamento {file}");
                File.Delete(file);
            }
        }
        catch (Exception ex)
        {
            _createLog.Log($"[ERRO] Erro ao deletar arquivo: {ex.Message}");
        }
    }

    public async Task Process(string path, string pathOutput, string pathError, List<(int dpi, int width, int height)> resizeAttempts)
    {
        string[] files = Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly);
        if (files.Length == 0)
            return;

        //Equilibrado para a maioria dos cenários e evita sobrecarregar o servidor.
        int maxParallelism = Math.Max(2, Environment.ProcessorCount / 2);
        try
        {
            _createLog.Log($"[INFO][PROCESSAMENTO] Início do processamento -  {DateTime.Now:HH:mm:ss}.");
            _createLog.Log($"[INFO] Processando diretório de entrada dos arquivos: {path}");

            await Parallel.ForEachAsync(files, new ParallelOptions { MaxDegreeOfParallelism = maxParallelism }, async (file, cancellationToken) =>
            {
                await ProcessFileAsync(file, pathOutput, pathError, resizeAttempts);
            });

            _createLog.Log($"[INFO][PROCESSAMENTO] Fim do processamento  - {DateTime.Now:HH:mm:ss}.");
            files = Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly);
            foreach (var file in files)
            {
                DeleteFile(file);
            }
        }
        catch (IOException ex)
        {
            _createLog.Log($"[ERRO] Processo de arquivos: {ex.Message}");
        }
    }
}
