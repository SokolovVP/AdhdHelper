namespace Application.Queries.ReadModels;

public sealed record ChallengeStageReadModel(
    Guid Id,
    string Name,
    int OrderNumber);