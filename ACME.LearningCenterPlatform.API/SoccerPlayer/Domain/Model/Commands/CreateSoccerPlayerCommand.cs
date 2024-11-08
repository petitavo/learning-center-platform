using ACME.LearningCenterPlatform.API.SoccerPlayer.Domain.Model.ValueObjects;

namespace ACME.LearningCenterPlatform.API.SoccerPlayer.Domain.Model.Commands;

public record CreateSoccerPlayerCommand(string Name, int Country, EPosition Position, DateTime BirthDate);