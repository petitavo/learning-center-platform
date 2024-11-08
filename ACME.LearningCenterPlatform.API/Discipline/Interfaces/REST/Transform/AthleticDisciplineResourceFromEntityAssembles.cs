using ACME.LearningCenterPlatform.API.Discipline.Domain.Model.Aggregate;
using ACME.LearningCenterPlatform.API.Discipline.Interfaces.REST.Resources;

namespace ACME.LearningCenterPlatform.API.Discipline.Interfaces.REST.Transform;

public static class AthleticDisciplineResourceFromEntityAssembles
{
    public static AthleticDisciplineResource ToResourceFromEntity(AthleticDiscipline entity)
    {
        return new AthleticDisciplineResource(entity.Id, entity.Name, entity.SportId, entity.Mode);
    }
}