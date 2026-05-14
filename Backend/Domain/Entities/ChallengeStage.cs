using Domain.ValueObjects;

namespace Domain.Entities;

public class ChallengeStage
{
    public Guid Id { get; init; }
    public Guid ChallengeId { get; init; }
    public ChallengeStageName Name { get; init; }

    private ChallengeStage(
        Guid id,
        Guid challengeId,
        ChallengeStageName name)
    {
        Id = id;
        ChallengeId = challengeId;
        Name = name;
    }

    public static ChallengeStage Create(
        Guid challengeId,
        string name)
    {
        return new ChallengeStage(
            Guid.CreateVersion7(),
            challengeId,
            ChallengeStageName.Create(name));
    }
}
