using System;
using Pharos.Application.Common;
using Pharos.Application.Dtos;
using Pharos.Domain.Common;

namespace Pharos.Application.Features.LightHouse;

public class GetAllLighthousesHandler(LighthouseRepository repository)
{
    private readonly LighthouseRepository _repository = repository;

    public async Task<Result<IEnumerable<LighthouseDto>>> HandleAsync()
    {
        var lighthouses = await _repository.GetAllAsync();

        if (!lighthouses.Any())
        {
            return Result<IEnumerable<LighthouseDto>>.Fail("No lighthouses found.");

        }

        var dtos = lighthouses.Select(l => new LighthouseDto(
            l.Id,
            l.Name,
            l.CountryId,
            l.Location.Latitude,
            l.Location.Longitude
        ));

        return Result<IEnumerable<LighthouseDto>>.Ok(dtos);

    }
}
