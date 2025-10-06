using System;
using Pharos.Application.Dtos;

namespace Pharos.Application.Contracts;

public interface IPhotoService
{
    Task<Guid> UploadAsync(PhotoDto dto, Stream fileContent);
    Task<Guid> DeleteAsync(Guid photoId);
}
