using System.Drawing;

namespace Pastinha.Service.Service.Process.Interface;

public interface IProcessEnhanceImageForQrCode
{
	Task<List<Bitmap>> EnhanceImageForQrCode(Bitmap originalImage);
}
