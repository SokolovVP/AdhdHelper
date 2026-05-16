using Domain.Exceptions;

namespace Domain.ValueObjects;

public sealed record ChallengeName
{
    public string Value { get; }

    private ChallengeName(string value) => Value = value;

    public static ChallengeName Create(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ValidationException("Challenge name can not be empty");
        }

        return new ChallengeName(value);
    }
}