using Pastinha.Service.Service.Process.Interface;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Pastinha.Service.Service.Process;

public class ResizeImage : IResizeImage
{
	public Bitmap? Image(Bitmap image, int dpi, int width, int height)
	{
		if (image is null)
			return null;

		var newImage = new Bitmap(width, height);
		newImage.SetResolution(dpi, dpi);

		using var graphics = Graphics.FromImage(newImage);
		graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
		graphics.SmoothingMode = SmoothingMode.HighQuality;
		graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
		graphics.CompositingQuality = CompositingQuality.HighQuality;

		graphics.DrawImage(image, 0, 0, width, height);

		return newImage;
	}

	public string Resize(string pathImage, int dpi, int width, int height)
	{
		var directory = Path.GetDirectoryName(pathImage);
		var filename = Path.GetFileNameWithoutExtension(pathImage);
		var newPath = Path.Combine(directory!, $"{filename}_resized.png");

		using var imagemOriginal = new Bitmap(pathImage);
		using var imagemNova = new Bitmap(width, height);

		imagemNova.SetResolution(dpi, dpi);

		using var g = Graphics.FromImage(imagemNova);
		g.InterpolationMode = InterpolationMode.HighQualityBicubic;
		g.SmoothingMode = SmoothingMode.AntiAlias;
		g.PixelOffsetMode = PixelOffsetMode.HighQuality;
		g.CompositingQuality = CompositingQuality.HighQuality;
		g.DrawImage(imagemOriginal, 0, 0, width, height);

		imagemNova.Save(newPath, ImageFormat.Png);

		return newPath;
	}
}
