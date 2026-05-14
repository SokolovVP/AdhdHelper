using Application.Abstractions;
using Domain.Aggregates;

namespace Infrastructure.EntityFramework.Repositories;

internal sealed class ChallengeRepository(AdhdHelperDbContext context) : IChallengeRepository
{
    public async Task Add(Challenge challenge)
    {
        context.Challenges.Add(challenge);
    }
}
