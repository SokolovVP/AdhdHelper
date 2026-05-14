using Domain.Aggregates;

namespace Application.Abstractions;

public interface IChallengeReadOnlyRepository
{
    Task<Challenge> GetById(Guid id);
}