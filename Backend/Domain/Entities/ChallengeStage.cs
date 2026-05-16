using Domain.ValueObjects;

namespace Domain.Entities;

public sealed class ChallengeStage
{
    public Guid Id { get; private set; }
    public ChallengeStageName Name { get; private set; }
    public ChallengeStageOrderNumber OrderNumber { get; private set; }
    public ChallengeStageCompletion Completion { get; private set; }

    private ChallengeStage(
        Guid id,
        ChallengeStageName name,
        ChallengeStageOrderNumber orderNumber,
        ChallengeStageCompletion completed)
    {
        Id = id;
        Name = name;
        OrderNumber = orderNumber;
        Completion = completed;
    }

    public static ChallengeStage Create(
        string name,
        int orderNumber)
    {
        return new ChallengeStage(
            Guid.CreateVersion7(),
            ChallengeStageName.Create(name),
            ChallengeStageOrderNumber.Create(orderNumber),
            ChallengeStageCompletion.NotCompleted());
    }
}