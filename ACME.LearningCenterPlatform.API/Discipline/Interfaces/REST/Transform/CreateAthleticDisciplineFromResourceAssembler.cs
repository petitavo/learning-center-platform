using ACME.LearningCenterPlatform.API.Discipline.Domain.Model.Commands;
using ACME.LearningCenterPlatform.API.Discipline.Domain.Model.ValueObjects;
using ACME.LearningCenterPlatform.API.Discipline.Interfaces.REST.Resources;

namespace ACME.LearningCenterPlatform.API.Discipline.Interfaces.REST.Transform;

public static class CreateAthleticDisciplineFromResourceAssembler
{
    public static CreateAthleticDisciplineCommand ToCommandFromResource(CreateAthleticDisciplineResource resource)
    {
        return new CreateAthleticDisciplineCommand(
            resource.Name,
            resource.SportId,
            Enum.Parse<EMode>(resource.Mode, true));
    }
}