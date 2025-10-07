using System;
using Pharos.Application.Common;
using Pharos.Application.Dtos;
using Pharos.Domain.Common;
using Pharos.Domain.Countries;
using Pharos.Domain.ValueObjects;

namespace Pharos.Application.Features.LightHouse;

public class CreateLighthouseHandler(ILighthouseRepository repository, ICountryRegistry countryRegistry)
{
    private readonly ILighthouseRepository _repository = repository;
    private readonly ICountryRegistry _countryRegistry = countryRegistry;


    public async Task<Result<Guid>> HandleAsync(LighthouseDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
            return Result<Guid>.Fail("Lighthouse name cannot be empty.");

        Country? country;
        try
        {
            country = _countryRegistry.GetById(dto.CountryId);
        }
        catch (Exception ex)
        {
            return Result<Guid>.Fail($"Country with ID {dto.CountryId} not found. {ex.Message}");
        }

        var location = new Coordinates(dto.Latitude, dto.Longitude);
        var lighthouse = new Domain.Entities.Lighthouse(dto.Name, country, location, dto.Id);
        await _repository.AddAsync(lighthouse);

        return Result<Guid>.Ok(lighthouse.Id);
    }
}