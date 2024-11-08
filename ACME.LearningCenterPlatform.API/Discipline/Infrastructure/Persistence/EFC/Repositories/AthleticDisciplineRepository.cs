using ACME.LearningCenterPlatform.API.Discipline.Domain.Model.Aggregate;
using ACME.LearningCenterPlatform.API.Discipline.Domain.Model.ValueObjects;
using ACME.LearningCenterPlatform.API.Discipline.Domain.Repositories;
using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ACME.LearningCenterPlatform.API.Discipline.Infrastructure.Persistence.EFC.Repositories;

public class AthleticDisciplineRepository(AppDbContext context) :
    BaseRepository<AthleticDiscipline>(context), IAthleticDisciplineRepository
{
    public async Task<bool> ExistsByNameSportAndMode(string name, string sportId, EMode mode)
    {
        return await Context.Set<AthleticDiscipline>()
            .AnyAsync(atlhetic => atlhetic.Name == name && atlhetic.SportId == sportId && atlhetic.Mode == mode);
    }
}