namespace ACME.LearningCenterPlatform.API.Subscriptions.Domain.Model.ValueObjects;

public enum EMonetizationStrategy
{
    None = 0,
    MonthlySubscription = 1,
    YearlySubscription = 2,
    PeTransactionFee = 3,
    OneTimePurchase = 4
}