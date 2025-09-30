using Pastinha.Service.Service.Process.Interface;
using Pastinha.Utility.Utility;
using System.Drawing;
using System.Drawing.Imaging;

namespace Pastinha.Service.Service.Process;

public class ProcessSaveImageEnhance(IProcessEnhanceImageForQrCode _processEnhanceImageForQrCode, CreateLog _createLog) : IProcessSaveImageEnhance
{
	public async Task<Bitmap?> ImageEnhance(string pathImage)
	{
		try
		{
			_createLog.Log($"[INFO] Inicio - Melhorando imagem: {pathImage}");

			using Bitmap originalImage = (Bitmap)Image.FromFile(pathImage);
			using Bitmap enhancedImage = await _processEnhanceImageForQrCode.EnhanceImageForQrCode(originalImage);

			_createLog.Log($"[INFO] Imagem melhorada: {pathImage}");
			_createLog.Log($"[INFO] Fim - Melhorando imagem");

			return new Bitmap(enhancedImage);
		}
		catch (Exception ex)
		{
			_createLog.Log($"[ERRO] Salvar imagem melhorada: {ex.Message}");
			return null;
		}
	}

	public async Task<string> SavePathImageEnhance(string pathImage)
	{
		try
		{
			_createLog.Log($"[INFO] Inicio - Melhorando imagem: {pathImage}");
			FileInfo fileInfo = new(pathImage);
			Guid guid = Guid.NewGuid();
			var directory = fileInfo.Directory!.FullName;

			string pathNewImage = Path.Combine(directory, $"{guid:N}.png");
			using Bitmap originalImage = (Bitmap)Image.FromFile(pathImage);
			using Bitmap enhancedImage = await _processEnhanceImageForQrCode.EnhanceImageForQrCode(originalImage);

			_createLog.Log($"[INFO] Nova imagem melhorada: {pathNewImage}");

			enhancedImage.Save(pathNewImage, ImageFormat.Png);

			_createLog.Log($"[INFO] Fim - Melhorando imagem");

			return pathNewImage;
		}
		catch (Exception ex)
		{
			_createLog.Log($"[ERRO] Salvar imagem melhorada: {ex.Message}");
			return string.Empty;
		}
	}
}
