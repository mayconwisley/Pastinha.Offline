using System.Drawing;

namespace Pastinha.Service.Service.Process.Interface;

public interface ICopyQrCodeImage
{
	Task<Bitmap> CopyQrCode(string pathImage);
}
