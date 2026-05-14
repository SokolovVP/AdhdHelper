using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Aggregates;

public class Challenge
{
    public Guid Id { get; init; }
    public ChallengeName Name { get; init; }
    public ICollection<ChallengeStage> Stages { get; init; } = [];

    private Challenge(
        Guid id,
        ChallengeName name)
    {
        Id = id;
        Name = name;
    }

    public static Challenge Create(
        string name)
    {
        return new Challenge(
            Guid.CreateVersion7(),
            ChallengeName.Create(name));
    }
}