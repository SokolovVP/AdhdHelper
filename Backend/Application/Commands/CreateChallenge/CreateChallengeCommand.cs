using Application.Commands.Dtos;

namespace Application.Commands.CreateChallenge;

public sealed record CreateChallengeCommand(
    string Name,
    IReadOnlyCollection<ChallengeStageDto> Stages);