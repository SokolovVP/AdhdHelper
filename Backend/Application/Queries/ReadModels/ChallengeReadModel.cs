namespace Application.Queries.ReadModels;

public sealed record ChallengeReadModel(
    Guid Id,
    string Name,
    IReadOnlyCollection<ChallengeStageReadModel> Stages);