using Application.Abstractions;
using Application.Queries.GetChallenge;
using Domain.Aggregates;
using Domain.Entities;
using Domain.Exceptions;

namespace Tests.Unit.QueryHandlers;

internal sealed class GetChallengeByIdQueryHandlerTests
{
    private readonly IChallengeReadOnlyRepositoryMock _challengeReadOnlyRepository;
    private readonly GetChallengByIdHandler _handler;

    public GetChallengeByIdQueryHandlerTests()
    {
        _challengeReadOnlyRepository = IChallengeReadOnlyRepository.Mock();
        _handler = new GetChallengByIdHandler();
    }

    [Test]
    [DisplayName("Должен вернуть данные по Id существующего челенджа")]
    public async Task HandleAsync_WithExistingId_ShouldReturnData()
    {
        var existingChallenge = Challenge.Create(
            "Test Challenge",
            new[] { ChallengeStage.Create("Stage 1", 1) });

        var challengeId = existingChallenge.Id;

        _challengeReadOnlyRepository.GetByIdAsync(Is(challengeId))
            .Returns(existingChallenge);

        var query = new GetChallengeByIdQuery(challengeId);

        var result = await _handler.HandleAsync(query, _challengeReadOnlyRepository);

        result.Should().NotBeNull();
        result.Id.Should().Be(challengeId);
        result.Name.Should().Be("Test Challenge");
    }

    [Test]
    [DisplayName("Должен бросить исключение, если нет челенджа с таким Id")]
    public async Task HandleAsync_WithNotExistingId_ShouldThrowException()
    {
        var challengeId = Guid.CreateVersion7();

        _challengeReadOnlyRepository.GetByIdAsync(Any())
            .Returns((Challenge?)null);

        var query = new GetChallengeByIdQuery(challengeId);

        await Assert.That(() =>
            _handler.HandleAsync(query, _challengeReadOnlyRepository)!)
            .Throws<NotFoundException>();
    }
}