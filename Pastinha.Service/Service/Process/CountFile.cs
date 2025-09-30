using Pastinha.Service.Service.Database.Interface;
using Pastinha.Service.Service.Process.Interface;
using Pastinha.Utility.Utility;

namespace Pastinha.Service.Service.Process;

public class CountFile(IServiceScopeFactory _serviceScopeFactory, CreateLog _createLog) : ICountFile
{
    public async Task CountFileFolder(string pathOutput)
    {
        using var scope = _serviceScopeFactory.CreateScope();
        var _returnCountDataFile = scope.ServiceProvider.GetRequiredService<IUpdateCountDataFile>();

        _createLog.Log("[INFO] Contando os arquivos");
        int countPdf = 0;
        int countImage = 0;
        int countOtherFormat = 0;

        string[] files = Directory.GetFiles(pathOutput, "*.*", SearchOption.AllDirectories);
        foreach (string file in files)
        {
            string extension = Path.GetExtension(file).ToLower();
            if (extension == ".pdf")
                countPdf++;
            else if (extension == ".png" || extension == ".jpg" || extension == ".jpeg" || extension == ".bmp")
                countImage++;
            else
                countOtherFormat++;
        }
        await _returnCountDataFile.UpdateCountAsync(countPdf, countImage, countOtherFormat);

        _createLog.Log("[INFO] Termino da contagem de arquivos");
    }
}
