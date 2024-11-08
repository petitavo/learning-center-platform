using ACME.LearningCenterPlatform.API.Kr.Domain.Model.Aggregate;
using ACME.LearningCenterPlatform.API.Kr.Interfaces.REST.Resources;

namespace ACME.LearningCenterPlatform.API.Kr.Interfaces.REST.Transform;

public static class KingrentalResourceFromEntityAssembler
{
    public static KingrentalResource ToResourceFromEntity(Kingrentals entity)
    {
        return new KingrentalResource(entity.Id, entity.Name, entity.DepartmentId, entity.DesiredJobTitle, entity.ResumeUrl);
    }
    
    
}