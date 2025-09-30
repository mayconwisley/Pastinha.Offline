using System.Drawing;

namespace Pastinha.Service.Service.Process.Interface;

public interface IResizeImage
{
	public string Resize(string pathImage, int dpi, int width, int height);
	public Bitmap? Image(Bitmap image, int dpi, int width, int height);
}
