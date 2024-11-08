using ACME.LearningCenterPlatform.API.Discipline.Domain.Model.ValueObjects;

namespace ACME.LearningCenterPlatform.API.Discipline.Domain.Model.Commands;

public record CreateAthleticDisciplineCommand(string Name, string SportId, EMode Mode);