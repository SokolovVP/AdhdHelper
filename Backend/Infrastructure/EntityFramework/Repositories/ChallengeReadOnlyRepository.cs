using Application.Abstractions;
using Domain.Aggregates;
using Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework.Repositories;

internal sealed class ChallengeReadOnlyRepository(AdhdHelperDbContext context) : IChallengeReadOnlyRepository
{
    public async Task<Challenge> GetByIdAsync(Guid id)
    {
        return await context.Challenges
            .Include(x => x.Stages)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id)
            ?? throw new NotFoundException("Challenge with required id was not found");
    }
}