using Pastinha.Base.Model.FromTo;

namespace Pastinha.Base.Repository.Interface;

public interface IFromToTypeRepository
{
    Task<IEnumerable<FromToType>?> GetAllAsync(int page = 1, int size = 15, string search = "");
    Task<FromToType?> GetByIdAsync(int id);
    Task<FromToType?> GetByFromToTypeAsync(int fromTipCol);
    Task<FromToType?> CreateAsync(FromToType fromToType);
    Task<FromToType?> UpdateAsync(FromToType fromToType);
    Task<FromToType?> DeleteAsync(int id);
}
