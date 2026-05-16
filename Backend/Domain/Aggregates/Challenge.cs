using Domain.Entities;
using Domain.Exceptions;
using Domain.ValueObjects;

namespace Domain.Aggregates;

public sealed class Challenge
{
    private readonly List<ChallengeStage> _stages = [];

    public Guid Id { get; private set; }
    public ChallengeName Name { get; private set; }
    public ChallengeCompletion Completion { get; private set; }
    public IReadOnlyCollection<ChallengeStage> Stages => _stages.AsReadOnly();

    private Challenge(
        Guid id,
        ChallengeName name,
        ChallengeCompletion completed,
        List<ChallengeStage> stages)
    {
        Id = id;
        Name = name;
        Completion = completed;
        _stages = stages;
    }

    public static Challenge Create(
        string name,
        IReadOnlyCollection<ChallengeStage> stages)
    {
        EnsureStagesHaveUniqueOrderNumbers(stages);

        return new Challenge(
            Guid.CreateVersion7(),
            ChallengeName.Create(name),
            ChallengeCompletion.NotCompleted(),
            stages.ToList());
    }

    private static void EnsureStagesHaveUniqueOrderNumbers(IReadOnlyCollection<ChallengeStage> stages)
    {
        if (stages.Select(item => item.OrderNumber)
            .ToHashSet().Count != stages.Count)
        {
            throw new ValidationException("Stages order numbers must be unique");
        }
    }
}