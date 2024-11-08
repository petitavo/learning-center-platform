using ACME.LearningCenterPlatform.API.Subscriptions.Domain.Model.ValueObjects;

namespace ACME.LearningCenterPlatform.API.Subscriptions.Interfaces.REST.Resources;

public record PlanResource(int Id, string Name, int MaxUsers, EMonetizationStrategy MonetizationStrategyId);