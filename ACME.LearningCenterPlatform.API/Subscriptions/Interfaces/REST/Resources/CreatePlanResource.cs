using System.ComponentModel.DataAnnotations;
using ACME.LearningCenterPlatform.API.Subscriptions.Domain.Model.ValueObjects;

namespace ACME.LearningCenterPlatform.API.Subscriptions.Interfaces.REST.Resources;

public record CreatePlanResource(
    string Name,
    int MaxUsers,
    int IsDefault,
    [EnumDataType(typeof(EMonetizationStrategy))]
    int MonetizationStrategyId
);