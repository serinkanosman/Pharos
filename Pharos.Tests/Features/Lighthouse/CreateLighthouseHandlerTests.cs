using System;
using Moq;
using Pharos.Application.Dtos;
using Pharos.Application.Features.LightHouse;
using Pharos.Domain.Common;
using Pharos.Domain.Countries;

namespace Pharos.Tests.Features.Lighthouse;

public class CreateLighthouseHandlerTests
{
    private readonly Mock<ILighthouseRepository> _repositoryMock;
    private readonly CreateLighthouseHandler _handler;
    private readonly Mock<ICountryRegistry> _registryMock;

    public CreateLighthouseHandlerTests()
    {
        _repositoryMock = new Mock<ILighthouseRepository>();
        _registryMock = new Mock<ICountryRegistry>();
        _handler = new CreateLighthouseHandler(_repositoryMock.Object, _registryMock.Object);
    }

    [Fact]
    public async Task HandleAsync_ShouldReturnSuccess_WhenInputIsValid()
    {
        // Arrange
        var dto = new LighthouseDto(
            Guid.NewGuid(),           // Id
            "Test Lighthouse",        // Name
            20,                        // Some int parameter (replace with appropriate value)
            45.0,                     // Latitude
            -73.0                     // Longitude
        );

        var country = new Country(20, "Test Country");
        _registryMock.Setup(r => r.GetById(dto.CountryId)).Returns(country);
        // Act
        var result = await _handler.HandleAsync(dto);

        // Assert
        Assert.True(result.Success);
        Assert.NotEqual(Guid.Empty, result.Data);

        _repositoryMock.Verify(r => r.AddAsync(It.IsAny<Domain.Entities.Lighthouse>()), Times.Once);
    }
    [Fact]
    public async Task HandleAsync_ShouldReturnFail_WhenCountryNotFound()
    {
        // Arrange
        var dto = new LighthouseDto(
            Guid.Empty,
            "Green Point", // Empty name
            999,
            0,
            0
        );
        _registryMock.Setup(r => r.GetById(It.IsAny<int>())).Throws(new Exception("Invalid country."));
        // Act
        var result = await _handler.HandleAsync(dto);

        // Assert
        Assert.False(result.Success);
        Assert.Contains("Invalid country.", result.ErrorMessage);

    }
}
