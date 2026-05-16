namespace Domain.ValueObjects;

public sealed record ChallengeStageCompletion
{
    public DateTime? CompletedAt { get; }
    public bool IsCompleted => CompletedAt.HasValue;

    private ChallengeStageCompletion(DateTime? completedAt)
    {
        CompletedAt = completedAt;
    }

    public static ChallengeStageCompletion NotCompleted() => new((DateTime?)null);

    public ChallengeStageCompletion Complete(DateTime completedAt) => new(completedAt);
}