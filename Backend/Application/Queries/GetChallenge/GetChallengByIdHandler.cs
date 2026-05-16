using Application.Abstractions;
using Application.Queries.ReadModels;
using Domain.Exceptions;

namespace Application.Queries.GetChallenge;

public sealed class GetChallengByIdHandler
{
    public async Task<ChallengeReadModel> HandleAsync(
        GetChallengeByIdQuery query,
        IChallengeReadOnlyRepository challengeRepository)
    {
        var challenge = await challengeRepository.GetByIdAsync(query.Id);

        if (challenge is null)
        {
            throw new NotFoundException("Challenge with required id was not found");
        }

        var challengeStages = challenge.Stages
            .Select(item => new ChallengeStageReadModel(
                item.Id,
                item.Name.Value,
                item.OrderNumber.Value))
            .ToList()
            .AsReadOnly();

        return new ChallengeReadModel(
            challenge.Id,
            challenge.Name.Value,
            challengeStages);
    }
}