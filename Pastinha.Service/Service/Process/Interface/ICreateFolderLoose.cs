namespace Pastinha.Service.Service.Process.Interface;

public interface ICreateFolderLoose
{
    bool Create(string file, string nameFile, string pathOutput);
    bool Create(string nameFile, string pathOutput);
}
