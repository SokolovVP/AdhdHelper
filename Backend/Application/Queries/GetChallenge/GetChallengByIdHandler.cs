using Application.Abstractions;
using Application.Queries.ReadModels;

namespace Application.Queries.GetChallenge;

public sealed class GetChallengByIdHandler
{
    public async Task<ChallengeReadModel> HandleAsync(
        GetChallengeByIdQuery query,
        IChallengeReadOnlyRepository challengeRepository)
    {
        var challenge = await challengeRepository.GetByIdAsync(query.Id);

        var challengeStages = challenge.Stages
            .Select(item => new ChallengeStageReadModel(
                item.Id,
                item.ChallengeId,
                item.Name.Value,
                item.OrderNumber.value))
            .ToList()
            .AsReadOnly();

        return new ChallengeReadModel(
            challenge.Id,
            challenge.Name.Value,
            challengeStages);
    }
}