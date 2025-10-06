using System;

namespace Pharos.Domain.ValueObjects;

public record class Rating(int Value)
{
    public static Rating FromValue(int value)
    {
        if (value < 1 || value > 5)
            throw new ArgumentOutOfRangeException(nameof(value), "Rating must be between 1 and 5.");

        return new Rating(value);

    }
}
