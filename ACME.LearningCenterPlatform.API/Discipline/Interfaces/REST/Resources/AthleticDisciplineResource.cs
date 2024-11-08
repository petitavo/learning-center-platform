using ACME.LearningCenterPlatform.API.Discipline.Domain.Model.ValueObjects;

namespace ACME.LearningCenterPlatform.API.Discipline.Interfaces.REST.Resources;

public record AthleticDisciplineResource(int Id, string Name, string SportId, EMode Mode);