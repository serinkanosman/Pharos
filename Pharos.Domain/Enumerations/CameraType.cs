using Pharos.Domain.Common;

namespace Pharos.Domain.Enumerations;

public sealed class CameraType : EnumerationBase
{
    private CameraType(int id, string name) : base(id, name) { }

    public static CameraType SLR => new(1, "SLR");
    public static CameraType DSLR => new(2, "DSLR");
    public static CameraType Mirrorless => new(3, "Mirrorless");
    public static CameraType Phone => new(4, "Phone");

    public static IEnumerable<CameraType> List() => new[] { SLR, DSLR, Mirrorless, Phone };

    public static CameraType FromId(int id) =>
        List().FirstOrDefault(ct => ct.Id == id)
        ?? throw new ArgumentOutOfRangeException($"Invalid CameraType Id: {id}");
        
    public static CameraType FromName(string name) =>
        List().FirstOrDefault(ct => string.Equals(ct.Name, name, StringComparison.OrdinalIgnoreCase))
        ?? throw new ArgumentException($"Invalid CameraType Name: {name}");
}