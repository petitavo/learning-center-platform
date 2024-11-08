using ACME.LearningCenterPlatform.API.SoccerPlayer.Domain.Model.Commands;

namespace ACME.LearningCenterPlatform.API.SoccerPlayer.Domain.Services;

public interface ISoccerPlayerCommandService
{
    public Task<Model.Aggregate.SoccerPlayer> Handle(CreateSoccerPlayerCommand command);
}