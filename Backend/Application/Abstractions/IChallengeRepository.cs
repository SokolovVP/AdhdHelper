using Domain.Aggregates;

namespace Application.Abstractions;

public interface IChallengeRepository
{
    Task AddAsync(Challenge challenge);
}