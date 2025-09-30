using Pastinha.Base.Model.Folder;
using Pastinha.Base.Repository.Interface;
using Pastinha.Service.Service.Database.Interface;
using Pastinha.Utility.Utility;

namespace Pastinha.Service.Service.Database;

public class ReturnPathPastinha(IServiceScopeFactory _serviceScopeFactory, CreateLog _createLog) : IReturnPathPastinha
{
	public async Task<FolderPastinhaSenior?> GetPathAsync()
	{
		try
		{
			using var scope = _serviceScopeFactory.CreateScope();
			var folderPastinha = scope.ServiceProvider.GetRequiredService<IFolderPastinhaRepository>();

			var folderPapel = await folderPastinha.GetFirstAsync();

			return folderPapel ?? null;
		}
		catch (Exception ex)
		{
			_createLog.Log($"[ERRO] Retorno Local {ex.Message}");
			return null;
		}
	}
}
