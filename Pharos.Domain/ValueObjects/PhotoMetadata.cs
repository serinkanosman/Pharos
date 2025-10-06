using System;

namespace Pharos.Domain.ValueObjects;

public record PhotoMetadata(string Lens,string Resolution,string CameraModel, DateTime TakenAt);
