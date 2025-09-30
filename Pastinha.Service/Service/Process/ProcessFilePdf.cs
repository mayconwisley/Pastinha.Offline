using Pastinha.Model.Model;
using Pastinha.Service.Service.Database.Interface;
using Pastinha.Service.Service.Dto.Mapping;
using Pastinha.Service.Service.Process.Interface;
using Pastinha.Utility.Utility;
using PdfiumViewer;
using System.Diagnostics;
using System.Drawing.Imaging;

namespace Pastinha.Service.Service.Process;

public class ProcessFilePdf(IProcessQrCodeImage _processQrCodeImage, IRenameFile _renameFile,
    ICreateFolder _createFolder, ICreateFolderLoose _createFolderLoose, ICreateUpdateEmployee _createUpdateEmployee,
    CreateLog _createLog) : IProcessFilePdf
{
    public async Task Process(string file, string pathOutput, string pathError, List<(int dpi, int width, int height)> resizeAttempts)
    {
        const int MAX_PARALLEL_MEMORY_MB = 1024;
        double estimatedPerPageMb = EstimateMemoryPerPageMb(1380, 1920, 4); // 10.6MB base -> uso conservador

        int maxParallelByMemory = Math.Max(1, (int)(MAX_PARALLEL_MEMORY_MB / Math.Max(1.0, estimatedPerPageMb)));

        //Equilibrado para a maioria dos cenários e evita sobrecarregar o servidor.
        int maxParallelism = Math.Max(1, Environment.ProcessorCount / 2);
        int maxParallel = Math.Min(maxParallelByMemory, maxParallelism);
        _createLog.Log($"[INFO] MaxParallel calculado. CPU-base: {maxParallelism}, Memória-base: {maxParallelByMemory}. Usando {maxParallel} workers.");

        var stopwatch = Stopwatch.StartNew();

        using var pdfReader = PdfDocument.Load(file);
        _createLog.Log($"[INFO][PDF] Iniciando processamento do arquivo PDF");

        Guid guid = Guid.NewGuid();
        string nameFile = Path.GetFileName(file);
        int pageCount = pdfReader.PageCount;

        await Parallel.ForEachAsync(Enumerable.Range(0, pageCount), new ParallelOptions { MaxDegreeOfParallelism = maxParallel }, async (currentPage, cancellationToken) =>
        {
            _createLog.Log($"[DEBUG] Threads ativas: {maxParallel}");
            _createLog.Log($"[INFO] Início do processamento da página: {currentPage}");

            string pathOutputImage = Path.Combine(pathOutput, $"{guid:N}-{currentPage}.png");
            _createLog.Log($"[INFO] Nome temporário do arquivo para conversão PNG: {pathOutputImage}");

            try
            {
                int dpi = 300;
                int width = 1380;
                int height = 1920;

                using var img = pdfReader.Render(currentPage, width, height, dpi, dpi, true);

                ImageCodecInfo? pngEncoder = ImageCodecInfo.GetImageEncoders()
                                                           .FirstOrDefault(codec => codec.FormatID == ImageFormat.Png.Guid);

                using var encoderParams = new EncoderParameters(1);
                encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, 100L);

                img.Save(pathOutputImage, pngEncoder!, encoderParams);

                _createLog.Log($"[SUCESSO] Conversão realizada com sucesso da página {currentPage}");
            }
            catch (Exception ex)
            {
                _createLog.Log($"[ERRO] Na conversão da página {currentPage} para .PNG: {ex.Message}");
                return;
            }

            try
            {
                var dataQrCode = await _processQrCodeImage.ProcessMultQrCodeMemory(pathOutputImage, pathError, resizeAttempts);

                if (dataQrCode is not null)
                {
                    // await CreateEmployee(dataQrCode); // Descomente se quiser ativar

                    string newPathOutput = await _createFolder.Create(dataQrCode, pathOutput);
                    _renameFile.Rename(dataQrCode, pathOutputImage, newPathOutput);
                }
                else
                {
                    _createLog.Log($"[AVISO] QRCode não encontrado na página: {currentPage}");
                    _createLog.Log($"[INFO] Verificando nome do arquivo: {pathOutputImage}");
                    _createFolderLoose.Create(file, pathOutputImage, pathOutput);
                }
            }
            catch (Exception ex)
            {
                _createLog.Log($"[ERRO] Processamento do QRCode na página {currentPage}: {ex.Message}");
            }

            _createLog.Log($"[INFO] Término do processamento da página: {currentPage}");
        });

        stopwatch.Stop();
        _createLog.Log($"[INFO][PDF] Término do processamento arquivo PDF, Tempo total de processamento: {stopwatch.Elapsed}");
    }
    private static double EstimateMemoryPerPageMb(int width, int height, int bytesPerPixel)
    {
        // width * height * bytesPerPixel -> bytes
        long pixels = (long)width * (long)height; // evita overflow
        long bytes = pixels * bytesPerPixel;
        double mb = bytes / (1024.0 * 1024.0);
        // adiciona overhead conservador (encoder, temporários) — multiplicador x3
        return Math.Max(1.0, mb * 3.0);
    }
    private async Task CreateEmployee(DataQrCode dataQrCode)
    {
        var employee = dataQrCode.ToQrCodeDataFromEmploye();

        try
        {
            await _createUpdateEmployee.CreateUpdadeAsync(employee!);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
