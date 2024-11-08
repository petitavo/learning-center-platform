using ACME.LearningCenterPlatform.API.SoccerPlayer.Domain.Model.ValueObjects;

namespace ACME.LearningCenterPlatform.API.SoccerPlayer.Interfaces.REST.Resources;

public record SoccerPlayerResource(int Id, string Name, int Country, EPosition Position, DateTime BirthDate);