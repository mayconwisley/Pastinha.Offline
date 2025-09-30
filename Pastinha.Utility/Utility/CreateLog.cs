namespace Pastinha.Utility.Utility;

public class CreateLog
{
    string _pathLog = string.Empty;
    readonly object _logLock = new();

    public void PathLog(string pathLog)
    {

        if (!string.IsNullOrEmpty(pathLog))
        {
            _pathLog = pathLog;
        }
        else
        {
            throw new Exception("É necessário informar o local do LOG");
        }
    }

    public void Log(string mensage)
    {
        try
        {
            lock (_logLock)
            {
                string nameFileLog = $"{DateTime.Now:yyyy-MM-dd HH}h - Log Pastinha.Exe.log";
                string pathLogName = Path.Combine(_pathLog, nameFileLog);
                if (!File.Exists(pathLogName))
                {
                    FileStream fileStream = File.Create(pathLogName);
                    fileStream.Close();
                }
                using StreamWriter streamWriter = File.AppendText(pathLogName);
                AppendLog(mensage, streamWriter);
            }
        }
        catch (IOException ex)
        {
            throw new IOException(ex.Message);
        }
    }

    private static void AppendLog(string mensage, TextWriter textWriter)
    {
        try
        {
            textWriter.Write($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}: ");
            textWriter.WriteLine(mensage);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
