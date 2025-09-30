namespace Pastinha.Service.Service.Database.Interface;

public interface IUpdateCountDataFile
{
	Task UpdateCountAsync(int countPdf = 0, int countImage = 0, int countOtherFormat = 0, int countSendPlatform = 0);
}
