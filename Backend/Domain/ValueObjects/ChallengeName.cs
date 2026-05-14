using Domain.Exceptions;

namespace Domain.ValueObjects;

public sealed record ChallengeName(string Value)
{
    public static ChallengeName Create(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ValidationException("Challenge name can not be empty");
        }

        return new ChallengeName(value);
    }
}