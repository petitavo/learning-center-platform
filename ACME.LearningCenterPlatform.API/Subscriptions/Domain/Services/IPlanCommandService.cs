using ACME.LearningCenterPlatform.API.Subscriptions.Domain.Model.Aggregate;
using ACME.LearningCenterPlatform.API.Subscriptions.Domain.Model.Commands;

namespace ACME.LearningCenterPlatform.API.Subscriptions.Domain.Services;

public interface IPlanCommandService
{
    public Task<Plan> Handle(CreatePlanCommand command);
}