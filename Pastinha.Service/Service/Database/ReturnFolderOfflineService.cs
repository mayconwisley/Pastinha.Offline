using Pastinha.Base.Model.Folder;
using Pastinha.Base.Repository.Interface;
using Pastinha.Service.Service.Database.Interface;
using Pastinha.Utility.Utility;

namespace Pastinha.Service.Service.Database;

public class ReturnFolderOfflineService(IServiceScopeFactory _serviceScopeFactory, CreateLog _createLog) : IReturnFolderOfflineService
{
	public async Task<FolderOfflinePastinhaSenior?> GetFolderOffline()
	{
		try
		{
			using var scope = _serviceScopeFactory.CreateScope();
			var folderOfflinePastinhaSenior1 = scope.ServiceProvider.GetRequiredService<IFolderOfflineRepository>();

			var folderOfflinePastinhaSenior = await folderOfflinePastinhaSenior1.GetFirstAsync();

			return folderOfflinePastinhaSenior ?? null;
		}
		catch (Exception ex)
		{
			_createLog.Log($"[ERRO] Folder Offline {ex.Message}");
			return null;
		}
	}
}
