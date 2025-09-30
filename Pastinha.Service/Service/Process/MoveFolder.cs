using Pastinha.Service.Service.Process.Interface;
using Pastinha.Utility.Constant;
using Pastinha.Utility.Utility;

namespace Pastinha.Service.Service.Process;

public class MoveFolder(CreateLog _createLog) : IMoveFolder
{
	public bool Move(string pathInput, string pathOutput)
	{
		if (Path.Exists(pathOutput))
			return false;

		if (Path.GetFullPath(pathInput).Split(Path.DirectorySeparatorChar).Contains(Constants.INACTIVES))
			pathOutput = pathOutput.Replace(Constants.ACTIVES, Constants.INACTIVES);

		if (Path.GetFullPath(pathInput).Split(Path.DirectorySeparatorChar).Contains(Constants.ACTIVES))
			pathOutput = pathOutput.Replace(Constants.INACTIVES, Constants.ACTIVES);

		if (!Directory.Exists(pathOutput))
		{
			_createLog.Log($"[INFO] Movendo arquivo para o diretório {pathOutput}");
			Directory.Move(pathInput, pathOutput);
			return true;
		}
		return false;
	}
}
