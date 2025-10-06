namespace Pastinha.Service.Service.Process.Interface;

public interface IProcessFile
{
	Task Process(string path, string pathOutput, string pathError);
}
