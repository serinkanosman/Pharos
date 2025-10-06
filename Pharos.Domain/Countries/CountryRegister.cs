
namespace Pharos.Domain.Countries;

public class CountryRegister(
    IEnumerable<Country> countries
) : ICountryRegistry

{
    private readonly Dictionary<int, Country> _countries = countries.ToDictionary(c => c.Id);
    public IReadOnlyList<Country> GetAll()
    {
        return   _countries.Values.ToList();
    }

    public Country GetById(int id)
    {
        return _countries.TryGetValue(id, out var country)
            ? country
            : throw new KeyNotFoundException($"Country with Id {id} not found.");
    }
}