using System;
using Pharos.Domain.Entities;

namespace Pharos.Domain.Interfaces;

public interface IPhotoRepository
{
    Task AddAsync(Photo photo);
    Task DeleteAsync(Guid id);
    Task<Photo?> GetByIdAsync(Guid id);
    Task<IEnumerable<Photo>> GetAllAsync(Guid lighthouseId);
    Task<IEnumerable<Photo>> GetByUserIdAsync(Guid userId);
}
