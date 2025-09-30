using Pastinha.Utility.Constant;
using System.Diagnostics;
using System.Management;
using System.ServiceProcess;

namespace Pastinha.Utility.Service;

public static class WindowsServices
{
	private static ServiceController GetServiceController() => new(Constants.NAME_SERVICE);
	public static string StatusService()
	{
		try
		{
			using var serviceController = GetServiceController();

			var serviceStatus = serviceController.Status;

			return serviceStatus switch
			{
				ServiceControllerStatus.Stopped => "Parado",
				ServiceControllerStatus.StartPending => "Início Pendente",
				ServiceControllerStatus.StopPending => "Parada Pendente",
				ServiceControllerStatus.Running => "Em Execução",
				ServiceControllerStatus.ContinuePending => "Continua Pendente",
				ServiceControllerStatus.PausePending => "Pausa Pendente",
				ServiceControllerStatus.Paused => "Em Pausa",
				_ => "Algo inesperado...",
			};
		}
		catch (InvalidOperationException ex)
		{
			throw new InvalidOperationException($"Serviço não instalado {ex.Message}");
		}
	}
	public static void StartService()
	{
		try
		{
			using var serviceController = GetServiceController();
			serviceController?.Start();
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}
	public static void StopService()
	{
		try
		{
			using var serviceController = GetServiceController();
			serviceController?.Stop();
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	private static string RetrieveProcessInstanceName(string serviceName)
	{
		var wmiQueryString = $"SELECT ProcessId FROM Win32_Service WHERE Name='{serviceName}'";
		using var searcher = new ManagementObjectSearcher(wmiQueryString);
		using var results = searcher.Get();
		var status = results.Cast<ManagementObject>().ToArray();

		var processId = Convert.ToInt32(results.Cast<ManagementObject>().First()["ProcessId"]);
		if (processId != 0)
		{
			var process = Process.GetProcessById(processId);
			return process.ProcessName;
		}
		else
		{
			return string.Empty;
		}
	}

	public static string CpuCounter()
	{
		try
		{
			string processName = RetrieveProcessInstanceName(Constants.NAME_SERVICE);

			if (string.IsNullOrEmpty(processName))
				return "Uso de CPU: 0% (Processo não encontrado ou serviço não iniciado)";

			var cpuCounter = new PerformanceCounter("Process", "% Processor Time", processName, true);

			// Primeira leitura (descartada)
			_ = cpuCounter.NextValue();
			Thread.Sleep(1000);

			// Segunda leitura (válida)
			float cpuUsage = cpuCounter.NextValue() / Environment.ProcessorCount; // Divide pela contagem de núcleos
			return $"Uso de CPU: {cpuUsage:0.0}%";
		}
		catch (Exception ex)
		{
			throw new Exception("Erro ao obter uso de CPU", ex);
		}

	}
	public static string MemoryCounter()
	{
		try
		{
			string processName = RetrieveProcessInstanceName(Constants.NAME_SERVICE);
			if (string.IsNullOrEmpty(processName))
			{
				return "Uso de Memória: 0MB (Processo não encontrado ou serviço não iniciado)";
			}

			var process = Process.GetProcessesByName(processName).FirstOrDefault();
			if (process == null)
			{
				return "Uso de Memória: 0MB (Processo não encontrado)";
			}

			long memUsageBytes = process.WorkingSet64;
			return $"Uso de Memória: {memUsageBytes / 1024.0 / 1024.0:#,###0.00}MB";
		}
		catch (Exception ex)
		{
			throw new Exception("Erro ao obter uso de memória", ex);
		}
	}
}
