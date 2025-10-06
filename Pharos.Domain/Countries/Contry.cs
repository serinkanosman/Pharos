
namespace Pharos.Domain.Countries;


public class Country
{
    public int Id { get; }
    public string Name { get; }

    public override string ToString() => Name;
    
    internal Country(int id, string name)
    {
        Id = id;
        Name = name;
    }

}