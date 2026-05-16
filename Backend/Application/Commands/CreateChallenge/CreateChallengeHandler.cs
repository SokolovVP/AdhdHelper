using Application.Abstractions;
using Domain.Aggregates;
using Domain.Entities;

namespace Application.Commands.CreateChallenge;

public sealed class CreateChallengeHandler
{
    public async Task HandleAsync(
        CreateChallengeCommand command,
        IChallengeRepository challengeRepository)
    {
        var stages = command.Stages
            .Select(item => ChallengeStage.Create(
                item.Name,
                item.OrderNumber))
            .ToList();

        var challenge = Challenge.Create(
            command.Name,
            stages);

        await challengeRepository.AddAsync(challenge);
    }
}