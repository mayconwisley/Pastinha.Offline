
using Pastinha.Utility.Constant;

namespace Pastinha.Base.Database;

public static class PastinhaStringConnection
{
	public static string ConnectionString()
	{
		var pastinhaDb = Environment.GetEnvironmentVariable(Constants.PASTINHA_BD, EnvironmentVariableTarget.Machine);

		if (string.IsNullOrEmpty(pastinhaDb))
			throw new InvalidOperationException("A string de conexão do banco de dados não foi definida.");

		var connectionString = $"Data Source = {pastinhaDb};Cache=Shared;Mode=ReadWriteCreate;";
		return connectionString;
	}
}
