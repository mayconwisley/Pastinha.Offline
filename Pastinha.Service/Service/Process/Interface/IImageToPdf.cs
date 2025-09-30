namespace Pastinha.Service.Service.Process.Interface;

public interface IImageToPdf
{
    public void Process(string[] imageFiles, string pathOutput);
}
