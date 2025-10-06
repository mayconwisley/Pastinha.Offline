using Pastinha.Model.Model;
using System.Drawing;

namespace Pastinha.Service.Service.Process.Interface;

public interface IProcessQrCodeImage
{
	Task<DataQrCode?> ProcessSingleQrCodeFile(string path, string pathError, List<(int dpi, int width, int height)> resizeAttempts);
	Task<DataQrCode?> ProcessSingleQrCodeMemory(string path, string pathError, List<(int dpi, int width, int height)> resizeAttempts);
	Task<DataQrCode?> ProcessSingleQrCodeMemory_1(Bitmap bitmap, string pathError, List<(int dpi, int width, int height)> resizeAttempts);
	Task<DataQrCode?> ProcessMultQrCodeMemory(string path, string pathError, List<(int dpi, int width, int height)> resizeAttempts);
}
