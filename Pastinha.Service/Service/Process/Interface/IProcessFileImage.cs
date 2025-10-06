namespace Pastinha.Service.Service.Process.Interface;

public interface IProcessFileImage
{
	Task Process(string file, string pathOutput, string pathError);
}
