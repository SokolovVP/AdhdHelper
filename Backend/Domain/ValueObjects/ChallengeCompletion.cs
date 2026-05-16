namespace Domain.ValueObjects;

public sealed record ChallengeCompletion
{
    public DateTime? CompletedAt { get; }
    public bool IsCompleted => CompletedAt.HasValue;

    private ChallengeCompletion(DateTime? completedAt)
    {
        CompletedAt = completedAt;
    }

    public static ChallengeCompletion NotCompleted() => new((DateTime?)null);

    public ChallengeCompletion Complete(DateTime completedAt) => new(completedAt);
}