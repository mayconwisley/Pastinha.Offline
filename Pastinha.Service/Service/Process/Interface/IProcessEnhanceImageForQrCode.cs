using System.Drawing;

namespace Pastinha.Service.Service.Process.Interface;

public interface IProcessEnhanceImageForQrCode
{
    Task<Bitmap> EnhanceImageForQrCode(Bitmap originalImage);
}
