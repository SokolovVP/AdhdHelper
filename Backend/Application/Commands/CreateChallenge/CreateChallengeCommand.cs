using Application.Commands.Dtos;

namespace Application.Commands.CreateChallenge;

public sealed record CreateChallengeCommand
{
    public required string Name { get; init; }
    public IReadOnlyCollection<ChallengeStageDto> Stages { get; init; } = [];
}