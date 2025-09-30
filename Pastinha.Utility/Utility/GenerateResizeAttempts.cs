namespace Pastinha.Utility.Utility;

public static class GenerateResizeAttempts
{
	public static List<(int dpi, int width, int height)> Generate(
		int dpi = 300,
		int startWidth = 240,
		int startHeight = 320,
		int steps = 9,
		double scaleFactor = 1.5,
		int maxWidth = 8000,
		int maxHeight = 8000)
	{
		var attempts = new List<(int dpi, int width, int height)>();

		int width = startWidth;
		int height = startHeight;

		for (int i = 0; i < steps; i++)
		{
			attempts.Add((dpi, Math.Min(width, maxWidth), Math.Min(height, maxHeight)));

			width = (int)(width * scaleFactor);
			height = (int)(height * scaleFactor);
		}

		return attempts;
	}
}
