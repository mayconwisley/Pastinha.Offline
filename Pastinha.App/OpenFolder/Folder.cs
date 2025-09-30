using Pastinha.Base.Repository.Interface;
using System.ComponentModel;
using System.Diagnostics;

namespace Pastinha.App.OpenFolder;

public class Folder(IFolderPastinhaRepository _folderPastinha, IFolderOfflineRepository _folderOfflineRepository)
{
    private void Open(string pathFolder)
    {
        try
        {
            Process.Start("explorer.exe", pathFolder);
        }
        catch (Win32Exception ex)
        {
            throw new Win32Exception(ex.Message);
        }
    }
    public async Task OpenInput()
    {
        var folders = await _folderPastinha.GetAll();

        var path = folders.Select(s => s.PathInput).FirstOrDefault();
        if (path is not null)
        {
            Open(path);
        }
        else
        {
            throw new Exception("Sem definição de caminho de Input");
        }
    }
    public async Task OpenOutput()
    {
        var folders = await _folderPastinha.GetAll();
        var path = folders.Select(s => s.PathOutput).FirstOrDefault();
        if (path is not null)
        {
            Open(path);
        }
        else
        {
            throw new Exception("Sem definição de caminho de Output");
        }
    }
    public async Task OpenError()
    {
        var folders = await _folderPastinha.GetAll();
        var path = folders.Select(s => s.PathError).FirstOrDefault();
        if (path is not null)
        {
            Open(path);
        }
        else
        {
            throw new Exception("Sem definição de caminho de Erro");
        }
    }
    public async Task OpenLog()
    {
        var folders = await _folderPastinha.GetAll();
        var path = folders.Select(s => s.PathLog).FirstOrDefault();
        if (path is not null)
        {
            Open(path);
        }
        else
        {
            throw new Exception("Sem definição de caminho de Log");
        }
    }
    public async Task OpenOffline()
    {
        var folders = await _folderOfflineRepository.GetAll();
        var path = folders.Select(s => s.PathOffline).FirstOrDefault();
        if (path is not null)
        {
            Open(path);
        }
        else
        {
            throw new Exception("Sem definição de caminho de Offline");
        }
    }
}
