using ACME.LearningCenterPlatform.API.Shared.Domain.Repositories;
using ACME.LearningCenterPlatform.API.Subscriptions.Domain.Model.Aggregate;

namespace ACME.LearningCenterPlatform.API.Subscriptions.Domain.Repositories;

public interface IPlanRepository : IBaseRepository<Plan>
{
    Task<bool> ExistsByNameAsync(string name);
    Task<bool> CantRegisterDefaultAsync(int isDefault);
}