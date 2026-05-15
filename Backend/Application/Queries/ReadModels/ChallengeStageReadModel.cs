namespace Application.Queries.ReadModels;

public sealed record ChallengeStageReadModel(
    Guid Id,
    Guid ChallengeId,
    string Name,
    int OrderNumber);