using ACME.LearningCenterPlatform.API.Discipline.Domain.Model.Aggregate;
using ACME.LearningCenterPlatform.API.Discipline.Domain.Model.ValueObjects;
using ACME.LearningCenterPlatform.API.Shared.Domain.Repositories;

namespace ACME.LearningCenterPlatform.API.Discipline.Domain.Repositories;

public interface IAthleticDisciplineRepository : IBaseRepository<AthleticDiscipline>
{
    Task<bool> ExistsByNameSportAndMode(string name, string sportId, EMode mode);
}