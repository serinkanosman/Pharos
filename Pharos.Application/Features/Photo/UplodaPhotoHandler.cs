using System;
using Pharos.Application.Common;
using Pharos.Application.Dtos;
using Pharos.Domain.Interfaces;
using Pharos.Domain.ValueObjects;

namespace Pharos.Application.Features.Photo;

public class UplodaPhotoHandler
{
    private readonly IPhotoStorageService _storageService;
    private readonly IPhotoRepository _repository;

    UplodaPhotoHandler(IPhotoRepository repository, IPhotoStorageService storageService)
    {
        _repository = repository;
        _storageService = storageService;
    }

    public async Task<Result<Guid>> HandleAsync(PhotoDto dto, Stream content)
    {
        if (content == null || content.Length == 0)
            return Result<Guid>.Fail("Photo content is empty.");

        var savedPath = await _storageService.SaveAsync(content, dto.FileName);

        var metadata = new PhotoMetadata(
            "N/A",
            "Unknown",
            dto.CameraModel,
            dto.UploadedAt
        );

        var photo = new Domain.Entities.Photo(dto.UserId, dto.LighthouseId,  savedPath, metadata);
        
        await _repository.AddAsync(photo);
        return Result<Guid>.Ok(photo.Id);
    }
    

}
