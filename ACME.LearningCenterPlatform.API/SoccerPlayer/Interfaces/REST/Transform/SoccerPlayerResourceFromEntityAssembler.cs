using ACME.LearningCenterPlatform.API.SoccerPlayer.Interfaces.REST.Resources;

namespace ACME.LearningCenterPlatform.API.SoccerPlayer.Interfaces.REST.Transform;

public static class SoccerPlayerResourceFromEntityAssembler
{
    public static SoccerPlayerResource ToResourceFromEntity(Domain.Model.Aggregate.SoccerPlayer entity)
    {
        return new SoccerPlayerResource(entity.Id, entity.Name, entity.Country, entity.Position, entity.BirthDate);
    }
}