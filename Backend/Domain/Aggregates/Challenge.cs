using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Aggregates;

public sealed class Challenge
{
    private readonly List<ChallengeStage> _stages = [];

    public Guid Id { get; private set; }
    public ChallengeName Name { get; private set; }
    public IReadOnlyCollection<ChallengeStage> Stages => _stages.AsReadOnly();

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

    public void AddStages(IEnumerable<ChallengeStage> stages)
    {
        _stages.AddRange(stages);
    }
}