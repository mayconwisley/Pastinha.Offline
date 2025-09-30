using Microsoft.EntityFrameworkCore;
using Pastinha.Base.Model.FileProcessed;
using Pastinha.Base.Repository.Interface;
using Pastinha.Service.Service.Database.Interface;

namespace Pastinha.Service.Service.Database;

public class CreateUpdateFileProcessed(IServiceScopeFactory _serviceScopeFactory) : ICreateUpdateFileProcessed
{
    public async Task CreateUpdateAsync(FileProcessed fileProcessed)
    {
        var dateProcessed = DateOnly.FromDateTime(DateTime.Now);

        using var scope = _serviceScopeFactory.CreateScope();
        var _fileProcessedRepository = scope.ServiceProvider.GetRequiredService<IFileProcessedRepository>();

        try
        {
            await _fileProcessedRepository.CreateAsync(fileProcessed);
        }
        catch (DbUpdateException ex) when (ex.InnerException?.Message.Contains("UNIQUE constraint failed") == true)
        {
            // 2. Já existe — faz o update com incremento de Amount
            var existingList = await _fileProcessedRepository.GetByEmployeeAsync(
                fileProcessed.NumEmp, fileProcessed.TipCol, fileProcessed.NumCad);

            var todayRecord = existingList!.FirstOrDefault(x => x.DateProcessed == dateProcessed)!.Id;
            if (todayRecord != 0)
            {
                await _fileProcessedRepository.UpdateAsync(todayRecord);
            }
            else
            {
                // fallback defensivo
                await _fileProcessedRepository.CreateAsync(fileProcessed);
            }
        }
    }


}
