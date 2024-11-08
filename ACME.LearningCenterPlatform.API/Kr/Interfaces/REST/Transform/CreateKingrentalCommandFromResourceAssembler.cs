using ACME.LearningCenterPlatform.API.Kr.Domain.Model.Commands;
using ACME.LearningCenterPlatform.API.Kr.Domain.Model.ValueObjects;
using ACME.LearningCenterPlatform.API.Kr.Interfaces.REST.Resources;

namespace ACME.LearningCenterPlatform.API.Kr.Interfaces.REST.Transform;

public static class CreateKingrentalCommandFromResourceAssembler
{
    public static CreateKingrentalCommand ToCommandFromResource(CreateKingrentalResource resource)
    {
        return new CreateKingrentalCommand(
            resource.Name,
            (EDepartment)resource.DepartmentId,
            resource.DesiredJobTitle,
            resource.ResumeUrl
        );
    }
    
    
}