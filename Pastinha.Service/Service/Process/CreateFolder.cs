using Pastinha.Model.Model;
using Pastinha.Service.Service.Database.Interface;
using Pastinha.Service.Service.Process.Interface;
using Pastinha.Utility.Constant;
using Pastinha.Utility.Utility;

namespace Pastinha.Service.Service.Process;

public class CreateFolder(IServiceScopeFactory _serviceScopeFactory, CreateLog _createLog) : ICreateFolder
{
	private string CreateDirectory(string pathOutput)
	{
		if (!Directory.Exists(pathOutput))
		{
			_createLog.Log($"[INFO] Tentando criar diretório: {pathOutput}");
			Directory.CreateDirectory(pathOutput);
			_createLog.Log($"[SUCESSO] Diretório criado: {pathOutput}");
		}
		else
		{
			_createLog.Log($"[SUCESSO] Diretório já existente: {pathOutput}");
		}
		return pathOutput;
	}
	public async Task<string> Create(DataQrCode dataQrCode, string pathOutput)
	{
		using var scope = _serviceScopeFactory.CreateScope();
		var _returnStatusFired = scope.ServiceProvider.GetRequiredService<IReturnStatusFired>();

		string nameFolder = string.Empty;
		_createLog.Log($"[INFO] Criando diretório com base no QRCode");

		if (!string.IsNullOrEmpty(dataQrCode.NomFun))
			nameFolder = @$"{dataQrCode.NumEmp:0000}-{dataQrCode.TipCol:00}-{dataQrCode.NumCad:00000000} - {RemoveAccents.Remover(dataQrCode.NomFun)}";
		else
			nameFolder = @$"{dataQrCode.NumEmp:0000}-{dataQrCode.TipCol:00}-{dataQrCode.NumCad:00000000}";

		_createLog.Log($"[INFO] Criando nome da diretório: {nameFolder}");
		string pathOutputCombine = string.Empty;

		var statusFired = await _returnStatusFired.GetStatusFiredAsync();

		var isStatusFired = statusFired.Any(a => a.CodeStatus.Equals(dataQrCode.SitAfa));

		if (isStatusFired)
			pathOutputCombine = Path.Combine(pathOutput, Constants.INACTIVES, nameFolder);
		else if (statusFired.Count() > 0)
			pathOutputCombine = Path.Combine(pathOutput, Constants.ACTIVES, nameFolder);
		else
			pathOutputCombine = Path.Combine(pathOutput, nameFolder);

		_createLog.Log($"[INFO] Criando novo caminho de saída para o arquivo: {pathOutputCombine}");

		return CreateDirectory(pathOutputCombine);
	}
	public string Create(string nameFile, string pathOutput)
	{
		//O nome dos arquivos deve iniciar com o número da empresa (4 dígitos), seguido do tipo de colaborador (2 dígitos) e do número de cadastro (8 dígitos).
		_createLog.Log($"[INFO] Criando diretório com base no nome do arquivo");
		bool isNumEmp = decimal.TryParse(nameFile[..4], out decimal numEmp);
		if (isNumEmp == false)
		{
			_createLog.Log($"[ERRO] Campo 'NumEmp' inválido no nome do arquivo");
			return string.Empty;
		}
		bool isTipCol = decimal.TryParse(nameFile.Substring(4, 2), out decimal tipCol);
		if (isTipCol == false)
		{
			_createLog.Log($"[ERRO] Campo 'TipCol' inválido no nome do arquivo");
			return string.Empty;
		}
		bool isNumCad = decimal.TryParse(nameFile.Substring(6, 8), out decimal numCad);
		if (isNumCad == false)
		{
			_createLog.Log($"[ERRO] Campo 'NumCad' inválido no nome do arquivo");
			return string.Empty;
		}

		string nameFolder = @$"{numEmp:0000}-{tipCol:00}-{numCad:00000000}";
		_createLog.Log($"[INFO] Criando nome do diretório {nameFolder}");
		string pathOutputCombine = Path.Combine(pathOutput, nameFolder);
		return CreateDirectory(pathOutputCombine);
	}
	public string Create(string nameFile) =>
		CreateDirectory(nameFile);
}
