using System.Diagnostics;
using System.Security.Principal;

namespace Pastinha.App.RestartAdmin;

public static class Restart
{
	public static void RestartAsAdmin()
	{
		try
		{
			var exePath = Application.ExecutablePath;

			var startInfo = new ProcessStartInfo(exePath)
			{
				UseShellExecute = true,
				Verb = "runas" // Isso ativa o UAC
			};

			Process.Start(startInfo);
			Application.Exit(); // Encerra o processo atual
		}
		catch (Exception ex)
		{
			MessageBox.Show($"Erro ao tentar reiniciar como administrador:\n{ex.Message}");
		}
	}
	public static bool IsRunningAsAdmin()
	{
		var identity = WindowsIdentity.GetCurrent();
		var principal = new WindowsPrincipal(identity);
		return principal.IsInRole(WindowsBuiltInRole.Administrator);
	}
}
