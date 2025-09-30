namespace Pastinha.Service.Service.Process.Interface;

public interface IProcessDirectory
{
	Task<int> ProcessDirectoryAsync(string directory, string accessToken);
}
