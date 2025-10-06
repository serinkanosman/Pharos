using Pharos.Domain.Common;

namespace Pharos.Domain.Enumerations;

public sealed class PhotoCategory : EnumerationBase
{
    private PhotoCategory(int id, string name) : base(id, name) { }

    
    public static PhotoCategory Sunset => new(1, "Sunset");
    public static PhotoCategory Historical => new(2, "Historical");
    public static PhotoCategory Storm => new(3, "Storm");
    public static PhotoCategory Sundown => new(4, "Sundown");

    public static IEnumerable<PhotoCategory> List() => new[] { Sunset, Historical, Storm, Sundown };

    public static PhotoCategory FromId(int id) =>
        List().FirstOrDefault(pc => pc.Id == id)
        ?? throw new ArgumentOutOfRangeException($"Invalid PhotoCategory Id: {id}");

}