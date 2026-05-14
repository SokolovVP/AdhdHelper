using Application.Abstractions;
using Domain.Aggregates;

namespace Infrastructure.EntityFramework.Repositories;

internal sealed class ChallengeRepository(AdhdHelperDbContext context) : IChallengeRepository
{
    public async Task AddAsync(Challenge challenge)
    {
        context.Challenges.Add(challenge);
    }
}