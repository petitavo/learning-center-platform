using ACME.LearningCenterPlatform.API.CRM.Domain.Model.Aggregate;
using ACME.LearningCenterPlatform.API.CRM.Interfaces.REST.Resources;

namespace ACME.LearningCenterPlatform.API.CRM.Interfaces.REST.Transform;

public static class ManagerResourceFromEntityAssembler
{
    public static ManagerResource ToResourceFromEntity(Manager entity)
    {
        return new ManagerResource(
            entity.Id,
            entity.VeterinaryCampaignManagerId,
            entity.FirstName,
            entity.LastName,
            entity.Status.ToString(),
            entity.ContactedAt,
            entity.ApprovedAt,
            entity.ReportedAt);
    }
}

