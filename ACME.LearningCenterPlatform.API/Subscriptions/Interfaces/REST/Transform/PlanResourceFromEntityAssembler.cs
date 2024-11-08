using ACME.LearningCenterPlatform.API.Subscriptions.Domain.Model.Aggregate;
using ACME.LearningCenterPlatform.API.Subscriptions.Interfaces.REST.Resources;

namespace ACME.LearningCenterPlatform.API.Subscriptions.Interfaces.REST.Transform;

public static class PlanResourceFromEntityAssembler
{
    public static PlanResource ToResourceFromEntity(Plan entity)
    {
        return new PlanResource(entity.Id, entity.Name, entity.MaxUsers, entity.MonetizationStrategyId);
    }
}