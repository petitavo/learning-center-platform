using ACME.LearningCenterPlatform.API.Subscriptions.Domain.Model.ValueObjects;

namespace ACME.LearningCenterPlatform.API.Subscriptions.Domain.Model.Commands;

public record CreatePlanCommand(string Name, int MaxUsers, int IsDefault, EMonetizationStrategy MonetizationStrategyId);