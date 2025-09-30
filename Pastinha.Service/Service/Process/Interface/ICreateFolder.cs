using Pastinha.Model.Model;

namespace Pastinha.Service.Service.Process.Interface;

public interface ICreateFolder
{
    public Task<string> Create(DataQrCode dataQrCode, string pathOutput);
    public string Create(string nameFile, string pathOutput);
    public string Create(string nameFile);
}
