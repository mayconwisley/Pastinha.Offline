namespace Pastinha.Service.Service.Process.Interface;

public interface IProcessFile
{
	Task Process(string path, string pathOutput, string pathError, List<(int dpi, int width, int height)> resizeAttempts);
}
