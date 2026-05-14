using Domain.ValueObjects;

namespace Domain.Entities;

public sealed class ChallengeStage
{
    public Guid Id { get; private set; }
    public Guid ChallengeId { get; private set; }
    public ChallengeStageName Name { get; private set; }
    public ChallengeStageOrderNumber OrderNumber { get; private set; }

    private ChallengeStage(
        Guid id,
        Guid challengeId,
        ChallengeStageName name,
        ChallengeStageOrderNumber orderNumber)
    {
        Id = id;
        ChallengeId = challengeId;
        Name = name;
        OrderNumber = orderNumber;
    }

    public static ChallengeStage Create(
        Guid challengeId,
        string name,
        int orderNumber)
    {
        return new ChallengeStage(
            Guid.CreateVersion7(),
            challengeId,
            ChallengeStageName.Create(name),
            ChallengeStageOrderNumber.Create(orderNumber));
    }
}