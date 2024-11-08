using ACME.LearningCenterPlatform.API.Shared.Domain.Repositories;
using ACME.LearningCenterPlatform.API.SoccerPlayer.Domain.Model.Commands;
using ACME.LearningCenterPlatform.API.SoccerPlayer.Domain.Repositories;
using ACME.LearningCenterPlatform.API.SoccerPlayer.Domain.Services;

namespace ACME.LearningCenterPlatform.API.SoccerPlayer.Application.Internal.CommandServices;

public class SoccerPlayerCommandService(
    ISoccerPlayerRepository soccerPlayerRepository,
    IUnitOfWork unitOfWork) : ISoccerPlayerCommandService
{
    public async Task<Domain.Model.Aggregate.SoccerPlayer> Handle(CreateSoccerPlayerCommand command)
    {
        if (await soccerPlayerRepository.ExistsByNameAndCountryAsync(command.Name, command.Country))
            throw new Exception("Soccer player with the same name and country already exists");
        var soccerPlayer = new Domain.Model.Aggregate.SoccerPlayer(command);
        await soccerPlayerRepository.AddAsync(soccerPlayer);
        await unitOfWork.CompleteAsync();
        return soccerPlayer;
    }
}