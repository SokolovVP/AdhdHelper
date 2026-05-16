using Application.Abstractions;
using Application.Commands.CreateChallenge;
using Application.Commands.Dtos;
using Domain.Aggregates;

namespace Tests.Unit.CommandHandlers;

internal sealed class CreateChallengeHandlerTests
{
    private readonly IChallengeRepositoryMock _challengeRepository;
    private readonly CreateChallengeHandler _handler;

    public CreateChallengeHandlerTests()
    {
        _challengeRepository = IChallengeRepository.Mock();
        _handler = new CreateChallengeHandler();
    }

    [Test]
    [DisplayName("При получении корректной команды сохраняет агрегат в репозиторий")]
    public async Task HandleAsync_WithCorrectCommand_SavesChallengeToRepository()
    {
        var command = new CreateChallengeCommand(
            "Complete the masters dissertation",
            [
                new ChallengeStageDto("Collect bibliographic sources", 1),
                new ChallengeStageDto("Make up the contents", 2),
                new ChallengeStageDto("Write the content", 3)
            ]);

        await _handler.HandleAsync(
            command,
            _challengeRepository);

        _challengeRepository.AddAsync(Any())
            .WasCalled(Times.Once);
    }

    [Test]
    [DisplayName("Должен сохранить челлендж с тремя этапами")]
    public async Task HandleAsync_WithThreeStages_SavesChallengeWithAllStages()
    {
        var command = new CreateChallengeCommand(
            "Complete the masters dissertation",
            [
                new ChallengeStageDto("Collect bibliographic sources", 1),
                new ChallengeStageDto("Make up the contents", 2),
                new ChallengeStageDto("Write the content", 3)
            ]);

        await _handler.HandleAsync(command, _challengeRepository);

        _challengeRepository.AddAsync(Is<Challenge>(c =>
            c is not null &&
            c.Stages.Count == 3 &&
            c.Name.Value == "Complete the masters dissertation"))
            .WasCalled(Times.Once);
    }

    [Test]
    [DisplayName("Должен создать челлендж в статусе NotCompleted")]
    public async Task HandleAsync_WithValidCommand_CreatesNotCompletedChallenge()
    {
        var command = new CreateChallengeCommand(
            "New challenge",
            [new ChallengeStageDto("Stage", 1)]);

        await _handler.HandleAsync(command, _challengeRepository);

        _challengeRepository.AddAsync(Is<Challenge>(c =>
            c is not null &&
            c.Completion.IsCompleted == false))
            .WasCalled(Times.Once);
    }
}