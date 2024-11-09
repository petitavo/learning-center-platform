using ACME.LearningCenterPlatform.API.CRM.Domain.Model.Commands;
using ACME.LearningCenterPlatform.API.CRM.Interfaces.REST.Resources;

namespace ACME.LearningCenterPlatform.API.CRM.Interfaces.REST.Transform;

public static class CreateManagerCommandFromResourceAssembler
{
    public static CreateManagerCommand ToCommandFromResource(CreateManagerResource resource)
    {
        return new CreateManagerCommand(
            resource.VeterinaryCampaignManagerId,
            resource.FirstName,
            resource.LastName,
            resource.Status,
            resource.ContactedAt,
            resource.ApprovedAt,
            resource.ReportedAt);
    }
    
}