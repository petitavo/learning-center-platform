using System.ComponentModel.DataAnnotations;
using ACME.LearningCenterPlatform.API.Discipline.Domain.Model.ValueObjects;

namespace ACME.LearningCenterPlatform.API.Discipline.Interfaces.REST.Resources;

public record CreateAthleticDisciplineResource(
    string Name,
    string SportId,
    [EnumDataType(typeof(EMode))] string Mode
);