using ACME.LearningCenterPlatform.API.Subscriptions.Domain.Model.Commands;
using ACME.LearningCenterPlatform.API.Subscriptions.Domain.Model.ValueObjects;
using ACME.LearningCenterPlatform.API.Subscriptions.Interfaces.REST.Resources;

namespace ACME.LearningCenterPlatform.API.Subscriptions.Interfaces.REST.Transform;

public static class CreatePlanCommandFromResourceAssembler
{
    public static CreatePlanCommand ToCommandFromResource(CreatePlanResource resource)
    {
        return new CreatePlanCommand(
            resource.Name,
            resource.MaxUsers,
            resource.IsDefault,
            (EMonetizationStrategy)resource.MonetizationStrategyId
        );
    }
}