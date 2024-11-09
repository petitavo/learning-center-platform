using System.ComponentModel.DataAnnotations;
using ACME.LearningCenterPlatform.API.SoccerPlayer.Domain.Model.ValueObjects;

namespace ACME.LearningCenterPlatform.API.SoccerPlayer.Interfaces.REST.Resources;

public record CreateSoccerPlayerResource(
    string Name,
    int Country,
    string Position,
    DateTime BirthDate);