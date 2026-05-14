using Domain.Aggregates;

namespace Application.Abstractions;

public interface IChallengeRepository
{
    Task Add(Challenge challenge);
}