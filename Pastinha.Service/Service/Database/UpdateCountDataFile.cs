using Pastinha.Service.Service.Database.Interface;

namespace Pastinha.Service.Service.Database;

public class UpdateCountDataFile(IServiceScopeFactory _serviceScopeFactory) : IUpdateCountDataFile
{
    public async Task UpdateCountAsync(int countPdf = 0, int countImage = 0, int countOtherFormat = 0, int countSendPlatform = 0)
    {
        using var scope = _serviceScopeFactory.CreateScope();
        var _returnCountDataFile = scope.ServiceProvider.GetRequiredService<IReturnCountDataFile>();
        var id = await _returnCountDataFile.GetFromIdDateCurrent();
        var countDataFile = await _returnCountDataFile.GetById(id);

        if (countDataFile is not null)
        {
            countDataFile.SetCount(countPdf, countImage, countOtherFormat, countSendPlatform);
            await _returnCountDataFile.Update(countDataFile);
        }
        else
        {
            countDataFile = new(DateTime.Now.Date, countPdf, countImage, countOtherFormat, countSendPlatform);
            await _returnCountDataFile.Create(countDataFile);
        }
    }
}
