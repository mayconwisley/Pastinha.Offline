using Microsoft.EntityFrameworkCore;
using Pastinha.Base.Database;
using Pastinha.Base.Model.Folder;
using Pastinha.Base.Repository.Interface;

namespace Pastinha.Base.Repository;

public class FolderOfflineRepository(PastinhaContext _pastinhaContext) : IFolderOfflineRepository
{
    public async Task<FolderOfflinePastinhaSenior> Create(FolderOfflinePastinhaSenior folderOfflinePastinhaSenior)
    {
        try
        {
            if (folderOfflinePastinhaSenior is not null)
            {
                _pastinhaContext.FoldersOffline.Add(folderOfflinePastinhaSenior);
                await _pastinhaContext.SaveChangesAsync();
                return folderOfflinePastinhaSenior;
            }
            return new();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<FolderOfflinePastinhaSenior> Delete(int id)
    {
        try
        {
            if (id != 0)
            {
                FolderOfflinePastinhaSenior folderOfflinePastinhaSenior = await GetById(id);

                _pastinhaContext.FoldersOffline.Remove(folderOfflinePastinhaSenior);
                await _pastinhaContext.SaveChangesAsync();
                return folderOfflinePastinhaSenior;
            }
            return new();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<IEnumerable<FolderOfflinePastinhaSenior>> GetAll(int page = 1, int size = 15, string search = "")
    {
        try
        {
            var folderOfflinePastinhaSeniorList = await _pastinhaContext.FoldersOffline
                .AsNoTracking()
                .Where(w => w.PathOffline!.ToLower().Contains(search.ToLower()))
                .OrderBy(o => o.PathOffline)
                .ToListAsync();

            return folderOfflinePastinhaSeniorList ?? [];
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<FolderOfflinePastinhaSenior> GetById(int id)
    {
        try
        {
            var folderOfflinePastinhaSenior = await _pastinhaContext.FoldersOffline
                .Where(w => w.Id == id)
                .FirstOrDefaultAsync();

            return folderOfflinePastinhaSenior ?? new();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<FolderOfflinePastinhaSenior> GetByName(string name)
    {
        try
        {
            var folderOfflinePastinhaSenior = await _pastinhaContext.FoldersOffline
               .Where(w => w.PathOffline!.ToLower().Contains(name.ToLower()))
               .OrderBy(o => o.PathOffline)
               .FirstOrDefaultAsync();

            return folderOfflinePastinhaSenior ?? new();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<FolderOfflinePastinhaSenior?> GetFirstAsync()
    {
        try
        {
            var folderOfflinePastinhaSeniorList = await _pastinhaContext.FoldersOffline
                .AsNoTracking()
                .OrderBy(o => o.Id)
                .FirstOrDefaultAsync();

            return folderOfflinePastinhaSeniorList ?? null;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<FolderOfflinePastinhaSenior> Update(FolderOfflinePastinhaSenior folderOfflinePastinhaSenior)
    {
        try
        {
            if (folderOfflinePastinhaSenior is not null)
            {
                FolderOfflinePastinhaSenior folderOfflinePastinhaSenior1 = await GetById(folderOfflinePastinhaSenior.Id);

                if (folderOfflinePastinhaSenior1 is not null)
                {
                    _pastinhaContext.FoldersOffline.Entry(folderOfflinePastinhaSenior1).CurrentValues.SetValues(folderOfflinePastinhaSenior);
                    await _pastinhaContext.SaveChangesAsync();

                    return folderOfflinePastinhaSenior;
                }
            }
            return new();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
