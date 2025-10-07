
namespace Pharos.Domain.Countries;


public class Country
{
    public Country(int id, string name)
    {
        Id = id;
        Name = name;
    }
    public int Id { get; }
    public string Name { get; }

    public override string ToString() => Name;
    
    

}