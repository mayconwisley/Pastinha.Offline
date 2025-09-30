namespace Pastinha.Service.Service.Process.Interface;

public interface IProcessFileExtension
{
    void Process(string file, string pathOutput, string pathError);
}
