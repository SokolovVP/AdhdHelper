using Domain.Exceptions;

namespace Domain.ValueObjects;

public sealed record ChallengeStageName(string Value)
{
    public static ChallengeStageName Create(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ValidationException("Challenge stage name can not be empty");
        }

        return new ChallengeStageName(value);
    }
}