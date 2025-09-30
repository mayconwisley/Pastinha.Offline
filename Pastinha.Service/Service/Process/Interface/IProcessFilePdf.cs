namespace Pastinha.Service.Service.Process.Interface;

public interface IProcessFilePdf
{
	Task Process(string file, string pathOutput, string pathError, List<(int dpi, int width, int height)> resizeAttempts);
}
