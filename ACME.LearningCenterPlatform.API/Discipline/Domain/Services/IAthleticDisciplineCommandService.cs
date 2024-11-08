using ACME.LearningCenterPlatform.API.Discipline.Domain.Model.Aggregate;
using ACME.LearningCenterPlatform.API.Discipline.Domain.Model.Commands;

namespace ACME.LearningCenterPlatform.API.Discipline.Domain.Services;

public interface IAthleticDisciplineCommandService
{
    public Task<AthleticDiscipline> Handle(CreateAthleticDisciplineCommand command);
}