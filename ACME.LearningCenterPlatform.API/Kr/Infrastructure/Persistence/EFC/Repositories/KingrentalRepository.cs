using ACME.LearningCenterPlatform.API.Kr.Domain.Model.Aggregate;
using ACME.LearningCenterPlatform.API.Kr.Domain.Model.ValueObjects;
using ACME.LearningCenterPlatform.API.Kr.Domain.Repositories;
using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ACME.LearningCenterPlatform.API.Kr.Infrastructure.Persistence.EFC.Repositories;

public class KingrentalRepository(AppDbContext context) :
    BaseRepository<Kingrentals>(context), IKingrentalRepository
{
    public async Task<bool> ExistsByNameAndDepartmentIdAsync(string name, EDepartment departmentId)
    {
        return await Context.Set<Kingrentals>()
            .AnyAsync(kingrental => kingrental.Name == name && kingrental.DepartmentId == departmentId);
    }
}