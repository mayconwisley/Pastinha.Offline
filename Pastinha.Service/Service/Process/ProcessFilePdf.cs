using Pastinha.Model.Model;
using Pastinha.Service.Service.Database.Interface;
using Pastinha.Service.Service.Dto.Mapping;
using Pastinha.Service.Service.Process.Interface;
using Pastinha.Utility.Utility;
using PdfiumViewer;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;

namespace Pastinha.Service.Service.Process;

public class ProcessFilePdf(IProcessQrCodeImage _processQrCodeImage, IRenameFile _renameFile,
	ICreateFolder _createFolder, ICreateUpdateEmployee _createUpdateEmployee,
	CreateLog _createLog) : IProcessFilePdf
{
	public async Task Process(string file, string pathOutput, string pathError)
	{
		const int MAX_PARALLEL_MEMORY_MB = 1024;
		const int DPI = 300;
		const int WIDTH = 820; //1380
		const int HEIGHT = 1080; //1920

		var resizeAttempts = GenerateResizeAttempts.Generate(DPI, WIDTH, HEIGHT);

		double estimatedPerPageMb = EstimateMemoryPerPageMb(WIDTH, HEIGHT, 4);

		int maxParallelByMemory = Math.Max(1, (int)(MAX_PARALLEL_MEMORY_MB / Math.Max(1.0, estimatedPerPageMb)));

		//Equilibrado para a maioria dos cenários e evita sobrecarregar o servidor.
		int maxParallelism = Math.Max(1, Environment.ProcessorCount / 2);
		int maxParallel = Math.Min(maxParallelByMemory, maxParallelism);
		_createLog.Log($"[INFO] MaxParallel calculado: {maxParallel} (CPU: {maxParallelism}, Memória: {maxParallelByMemory}).");
		_createLog.Log($"[INFO] Memória estimada por página: {estimatedPerPageMb:F2}MB");

		var stopwatch = Stopwatch.StartNew();

		using var pdfReader = PdfDocument.Load(file);
		_createLog.Log($"[INFO][PDF] Iniciando processamento do arquivo PDF");

		Guid guid = Guid.NewGuid();
		string nameFile = Path.GetFileName(file);
		int pageCount = pdfReader.PageCount;

		await Parallel.ForEachAsync(Enumerable.Range(0, pageCount),
			new ParallelOptions { MaxDegreeOfParallelism = maxParallel },
			async (currentPage, cancellationToken) =>
		{
			var threadInfo = $"Thread[{Thread.CurrentThread.ManagedThreadId}]";
			_createLog.Log($"[DEBUG][{threadInfo}] Threads ativas: {maxParallel}");
			_createLog.Log($"[INFO][{threadInfo}] Início do processamento da página: {currentPage + 1}");

			string pathOutputImage = Path.Combine(pathOutput, $"{guid:N}-{currentPage + 1}.png");
			_createLog.Log($"[INFO][{threadInfo}] Nome temporário do arquivo para conversão PNG: {pathOutputImage}");

			Bitmap bitmap;
			try
			{
				using var img = pdfReader.Render(currentPage, WIDTH, HEIGHT, DPI, DPI, true);

				bitmap = new(img);

				ImageCodecInfo? pngEncoder = ImageCodecInfo.GetImageEncoders()
														   .FirstOrDefault(codec => codec.FormatID == ImageFormat.Png.Guid);

				using var encoderParams = new EncoderParameters(1);
				encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, 100L);

				img.Save(pathOutputImage, pngEncoder!, encoderParams);

				_createLog.Log($"[SUCESSO][{threadInfo}] Conversão realizada com sucesso da página {currentPage + 1}");
			}
			catch (Exception ex)
			{
				_createLog.Log($"[ERRO][{threadInfo}] Na conversão da página {currentPage + 1} para .PNG: {ex.Message}");
				return;
			}

			try
			{
				var dataQrCode = await _processQrCodeImage.ProcessSingleQrCodeMemory_1(bitmap, pathError, resizeAttempts);

				if (dataQrCode is not null)
				{
					// await CreateEmployee(dataQrCode); // Descomente se quiser ativar

					string newPathOutput = await _createFolder.Create(dataQrCode, pathOutput);
					_renameFile.Rename(dataQrCode, pathOutputImage, newPathOutput);
				}
				else
				{
					_createLog.Log($"[AVISO][{threadInfo}] QRCode não encontrado na página: {currentPage + 1}");
				}
			}
			catch (Exception ex)
			{
				_createLog.Log($"[ERRO][{threadInfo}] Processamento do QRCode na página {currentPage + 1}: {ex.Message}");
			}

			_createLog.Log($"[INFO][{threadInfo}] Término do processamento da página: {currentPage + 1}");
		});

		stopwatch.Stop();
		_createLog.Log($"[INFO][PDF] Término do processamento arquivo PDF, Tempo total de processamento: {stopwatch.Elapsed}");
	}
	private static double EstimateMemoryPerPageMb(int width, int height, int bytesPerPixel)
	{
		long pixels = (long)width * (long)height;
		long bytes = pixels * bytesPerPixel;
		double mb = bytes / (1024.0 * 1024.0);
		return Math.Max(1.0, mb * 2.0);
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
