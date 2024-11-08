using ACME.LearningCenterPlatform.API.SoccerPlayer.Domain.Model.Commands;
using ACME.LearningCenterPlatform.API.SoccerPlayer.Domain.Model.ValueObjects;
using ACME.LearningCenterPlatform.API.SoccerPlayer.Interfaces.REST.Resources;

namespace ACME.LearningCenterPlatform.API.SoccerPlayer.Interfaces.REST.Transform;

public static class CreateSoccerPlayerCommandFromResourceAssembler
{
    public static CreateSoccerPlayerCommand ToCommandFromResource(CreateSoccerPlayerResource resource)
    {
        return new CreateSoccerPlayerCommand(
            resource.Name,
            resource.Country,
            Enum.Parse<EPosition>(resource.Position, true),
            resource.BirthDate
        );
    }
}