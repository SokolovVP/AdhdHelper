using System.ComponentModel.DataAnnotations;

namespace Domain.ValueObjects;

public sealed record ChallengeStageOrderNumber
{
    public int Value { get; }

    private ChallengeStageOrderNumber(int value) => Value = value;

    public static ChallengeStageOrderNumber Create(int value)
    {
        if (value < 0)
        {
            throw new ValidationException("Challenge stage order number can not be less than 0");
        }

        return new ChallengeStageOrderNumber(value);
    }
}