using Domain.Aggregates;

namespace Application.Abstractions;

public interface IChallengeReadOnlyRepository
{
    Task<Challenge> GetByIdAsync(Guid id);
}