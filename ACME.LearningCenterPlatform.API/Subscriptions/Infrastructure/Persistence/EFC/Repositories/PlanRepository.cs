using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using ACME.LearningCenterPlatform.API.Subscriptions.Domain.Model.Aggregate;
using ACME.LearningCenterPlatform.API.Subscriptions.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ACME.LearningCenterPlatform.API.Subscriptions.Infrastructure.Persistence.EFC.Repositories;

public class PlanRepository(AppDbContext context) :
    BaseRepository<Plan>(context), IPlanRepository
{
    public async Task<bool> ExistsByNameAsync(string name)
    {
        return await Context.Set<Plan>()
            .AnyAsync(plan => plan.Name == name);
    }

    public async Task<bool> CantRegisterDefaultAsync(int isDefault)
    {
        return await Context.Set<Plan>()
            .AnyAsync(plan => plan.IsDefault == isDefault && plan.IsDefault == 1);
    }
}