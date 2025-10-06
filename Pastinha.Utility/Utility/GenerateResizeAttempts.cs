namespace Pastinha.Utility.Utility;

public static class GenerateResizeAttempts
{
	public static List<(int dpi, int width, int height)> Generate(
		int dpi = 300,
		int startWidth = 120,
		int startHeight = 380,
		int steps = 12,
		double scaleFactor = 1.5,
		int maxWidth = 10000,
		int maxHeight = 10000,
		int fixedDifference = 260)
	{
		var attempts = new List<(int dpi, int width, int height)>();

		int width = startWidth;
		int height = startHeight;

		for (int i = 0; i < steps; i++)
		{
			//height = width + fixedDifference;

			attempts.Add((dpi, Math.Min(width, maxWidth), Math.Min(height, maxHeight)));

			width = (int)(width * scaleFactor);
			height = (int)(height * scaleFactor);
		}

		return attempts;
	}
}
