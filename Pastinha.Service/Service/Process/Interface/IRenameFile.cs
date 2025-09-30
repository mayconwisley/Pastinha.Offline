using Pastinha.Model.Model;

namespace Pastinha.Service.Service.Process.Interface;

public interface IRenameFile
{
    public void Rename(string pathOutputImage, string pathOutput);
    public void Rename(DataQrCode dataQrCode, string pathOutputImage, string pathOutput);
}
