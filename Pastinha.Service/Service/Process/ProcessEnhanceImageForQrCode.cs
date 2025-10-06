using Pastinha.Service.Service.Process.Interface;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Pastinha.Service.Service.Process;

public class ProcessEnhanceImageForQrCode : IProcessEnhanceImageForQrCode
{

	private readonly float[] _contrastLevels = { 1.2f, 1.5f, 1.8f, 2.0f };
	private readonly int[] _thresholdLevels = { 80, 100, 120, 140, 160 };
	private readonly RotateFlipType[] _rotations =
	{
		RotateFlipType.RotateNoneFlipNone,
		RotateFlipType.Rotate90FlipNone,
		RotateFlipType.Rotate180FlipNone,
		RotateFlipType.Rotate270FlipNone
	};

	public async Task<List<Bitmap>> EnhanceImageForQrCode(Bitmap originalImage)
	{
		var results = new List<Bitmap>();

		// Converte primeiro para grayscale
		using Bitmap grayImage = ConvertToGrayscale(originalImage);

		foreach (var contrast in _contrastLevels)
		{
			using Bitmap contrastImage = AdjustContrast(grayImage, contrast);

			foreach (var threshold in _thresholdLevels)
			{
				using Bitmap binImage = ApplyAdaptiveBinarization(contrastImage, threshold);

				foreach (var rotation in _rotations)
				{
					Bitmap rotated = (Bitmap)binImage.Clone();
					rotated.RotateFlip(rotation);
					results.Add(rotated);
				}
			}
		}

		return await Task.FromResult(results);
	}

	private Bitmap ConvertToGrayscale(Bitmap original)
	{
		Bitmap grayImage = new(original.Width, original.Height, PixelFormat.Format24bppRgb);
		BitmapData originalData = original.LockBits(new Rectangle(0, 0, original.Width, original.Height),
			ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
		BitmapData grayData = grayImage.LockBits(new Rectangle(0, 0, grayImage.Width, grayImage.Height),
			ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

		int bytes = Math.Abs(originalData.Stride) * original.Height;
		byte[] pixelBuffer = new byte[bytes];
		Marshal.Copy(originalData.Scan0, pixelBuffer, 0, bytes);
		original.UnlockBits(originalData);

		var options = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount };
		const double r = 0.3, g = 0.59, b = 0.11;

		Parallel.For(0, pixelBuffer.Length / 3, options, i =>
		{
			int index = i * 3;
			byte gray = (byte)((pixelBuffer[index] * b) + (pixelBuffer[index + 1] * g) + (pixelBuffer[index + 2] * r));
			pixelBuffer[index] = gray;
			pixelBuffer[index + 1] = gray;
			pixelBuffer[index + 2] = gray;
		});

		Marshal.Copy(pixelBuffer, 0, grayData.Scan0, bytes);
		grayImage.UnlockBits(grayData);
		return grayImage;
	}

	private Bitmap AdjustContrast(Bitmap image, float contrast)
	{
		Bitmap adjustedImage = new(image.Width, image.Height, PixelFormat.Format24bppRgb);
		BitmapData imageData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
			ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
		BitmapData adjustedData = adjustedImage.LockBits(new Rectangle(0, 0, adjustedImage.Width, adjustedImage.Height),
			ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

		int bytes = Math.Abs(imageData.Stride) * image.Height;
		byte[] pixelBuffer = new byte[bytes];
		Marshal.Copy(imageData.Scan0, pixelBuffer, 0, bytes);
		image.UnlockBits(imageData);

		float adjustment = (100.0f + contrast) / 100.0f;
		adjustment *= adjustment;

		var options = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount };

		int width = image.Width;
		int height = image.Height;

		Parallel.For(0, height, options, y =>
		{
			int row = y * imageData.Stride;
			for (int x = 0; x < width; x++)
			{
				int i = row + (x * 3);
				for (int c = 0; c < 3; c++)
				{
					float color = pixelBuffer[i + c] / 255.0f;
					color = (((color - 0.5f) * adjustment) + 0.5f) * 255.0f;
					pixelBuffer[i + c] = (byte)Math.Clamp(color, 0, 255);
				}
			}
		});

		Marshal.Copy(pixelBuffer, 0, adjustedData.Scan0, bytes);
		adjustedImage.UnlockBits(adjustedData);
		return adjustedImage;
	}

	private Bitmap ApplyAdaptiveBinarization(Bitmap image, int threshold)
	{
		Bitmap binaryImage = new(image.Width, image.Height, PixelFormat.Format24bppRgb);
		BitmapData imageData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
			ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
		BitmapData binaryData = binaryImage.LockBits(new Rectangle(0, 0, binaryImage.Width, binaryImage.Height),
			ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

		int bytes = Math.Abs(imageData.Stride) * image.Height;
		byte[] pixelBuffer = new byte[bytes];
		Marshal.Copy(imageData.Scan0, pixelBuffer, 0, bytes);
		image.UnlockBits(imageData);

		var options = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount };

		int width = image.Width;
		int height = image.Height;

		Parallel.For(0, height, options, y =>
		{
			int row = y * imageData.Stride;
			for (int x = 0; x < width; x++)
			{
				int i = row + (x * 3);
				byte val = (byte)(pixelBuffer[i] > threshold ? 255 : 0);
				pixelBuffer[i] = val;
				pixelBuffer[i + 1] = val;
				pixelBuffer[i + 2] = val;
			}
		});

		Marshal.Copy(pixelBuffer, 0, binaryData.Scan0, bytes);
		binaryImage.UnlockBits(binaryData);
		return binaryImage;
	}
}
