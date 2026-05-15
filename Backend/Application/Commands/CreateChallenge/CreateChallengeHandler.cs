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
        var challenge = Challenge.Create(command.Name);

        var stages = command.Stages
            .Select(item => ChallengeStage.Create(
                challenge.Id,
                item.Name,
                item.OrderNumber))
            .ToList();

        challenge.AddStages(stages);

        await challengeRepository.AddAsync(challenge);
    }
}