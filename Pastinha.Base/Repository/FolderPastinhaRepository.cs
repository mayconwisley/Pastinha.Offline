using Microsoft.EntityFrameworkCore;
using Pastinha.Base.Database;
using Pastinha.Base.Model.Folder;
using Pastinha.Base.Repository.Interface;

namespace Pastinha.Base.Repository;

public class FolderPastinhaRepository(PastinhaContext _pastinhaContext) : IFolderPastinhaRepository
{
    public async Task<FolderPastinhaSenior> Create(FolderPastinhaSenior folderPastinha)
    {
        try
        {
            if (folderPastinha is not null)
            {
                _pastinhaContext.FoldersPastinha.Add(folderPastinha);
                await _pastinhaContext.SaveChangesAsync();
                return folderPastinha;
            }
            return new();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public async Task<FolderPastinhaSenior> Delete(int id)
    {
        try
        {
            if (id != 0)
            {
                FolderPastinhaSenior folderPastinha = await GetById(id);

                _pastinhaContext.FoldersPastinha.Remove(folderPastinha);
                await _pastinhaContext.SaveChangesAsync();
                return folderPastinha;
            }
            return new();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public async Task<IEnumerable<FolderPastinhaSenior>> GetAll(int page = 1, int size = 15, string search = "")
    {
        try
        {
            var folderPastinhaSeniorList = await _pastinhaContext.FoldersPastinha
                .AsNoTracking()
                .Where(w => w.PathInput!.ToLower().Contains(search.ToLower()) ||
                            w.PathOutput!.ToLower().Contains(search.ToLower()) ||
                            w.PathLog!.ToLower().Contains(search.ToLower()))
                .OrderBy(o => o.PathInput)
                .ToListAsync();

            return folderPastinhaSeniorList ?? [];
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public async Task<FolderPastinhaSenior> GetById(int id)
    {
        try
        {
            var folderPastinhaSenior = await _pastinhaContext.FoldersPastinha
               .FirstOrDefaultAsync(w => w.Id == id);

            return folderPastinhaSenior ?? new();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public async Task<FolderPastinhaSenior> GetByName(string name)
    {
        try
        {
            var folderPastinhaSenior = await _pastinhaContext.FoldersPastinha
               .Where(w => w.PathInput!.ToLower().Contains(name.ToLower()) ||
                           w.PathOutput!.ToLower().Contains(name.ToLower()) ||
                           w.PathLog!.ToLower().Contains(name.ToLower()))
               .OrderBy(o => o.PathInput)
               .FirstOrDefaultAsync();

            return folderPastinhaSenior ?? new();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<FolderPastinhaSenior?> GetFirstAsync()
    {
        try
        {
            var folderPastinhaSeniorList = await _pastinhaContext.FoldersPastinha
                .OrderBy(o => o.Id)
                .FirstOrDefaultAsync();

            return folderPastinhaSeniorList ?? null;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<FolderPastinhaSenior> Update(FolderPastinhaSenior folderPastinha)
    {
        try
        {
            if (folderPastinha is not null)
            {
                FolderPastinhaSenior folderPastinhaSenior = await GetById(folderPastinha.Id);

                if (folderPastinhaSenior is not null)
                {
                    _pastinhaContext.FoldersPastinha.Entry(folderPastinhaSenior).CurrentValues.SetValues(folderPastinha);
                    await _pastinhaContext.SaveChangesAsync();

                    return folderPastinha;
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
