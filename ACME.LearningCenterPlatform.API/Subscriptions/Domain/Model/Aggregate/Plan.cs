using ACME.LearningCenterPlatform.API.Subscriptions.Domain.Model.Commands;
using ACME.LearningCenterPlatform.API.Subscriptions.Domain.Model.ValueObjects;

namespace ACME.LearningCenterPlatform.API.Subscriptions.Domain.Model.Aggregate;

public partial class Plan
{
    protected Plan()
    {
        Name = string.Empty;
        MaxUsers = int.MinValue;
        IsDefault = int.MinValue;
        MonetizationStrategyId = EMonetizationStrategy.None;
    }

    public Plan(CreatePlanCommand command)
    {
       
        Name = command.Name;
        MaxUsers = command.MaxUsers;
        IsDefault = command.IsDefault;
        MonetizationStrategyId = command.MonetizationStrategyId;
    }

    public int Id { get; }
    public string Name { get; private set; }
    public int MaxUsers { get; private set; }
    public int IsDefault { get; private set; }
    public EMonetizationStrategy MonetizationStrategyId { get; private set; }
}