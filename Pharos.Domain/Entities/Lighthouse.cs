using System;
using Pharos.Domain.Common;
using Pharos.Domain.Countries;
using Pharos.Domain.ValueObjects;

namespace Pharos.Domain.Entities;

public class Lighthouse : EntityBase
{
    public string Name { get;private set; }
    public int CountryId { get; private set; }
    public Country Country { get; private set; }
    public Coordinates Location { get;private set; }
    public List<Photo> Photos { get; } = [];
    protected Lighthouse() { }
    public Lighthouse(string name, Country country, Coordinates location, Guid? id = null) 
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Country = country ?? throw new ArgumentNullException(nameof(country));
        Location = location;
        CountryId = country.Id;
    }
}
