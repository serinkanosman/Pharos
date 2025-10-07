using Pharos.Domain.Entities;

namespace Pharos.Domain.Common;

public interface ILighthouseRepository
{
    Task AddAsync(Lighthouse lighthouse);
    Task UpdateAsync(Lighthouse lighthouse);
    Task DeleteAsync(Guid id);
    Task<Lighthouse?> GetByIdAsync(Guid id);
    Task<IEnumerable<Lighthouse>> GetAllAsync();
}