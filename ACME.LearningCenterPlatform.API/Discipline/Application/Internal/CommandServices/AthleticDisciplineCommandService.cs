using ACME.LearningCenterPlatform.API.Discipline.Domain.Model.Aggregate;
using ACME.LearningCenterPlatform.API.Discipline.Domain.Model.Commands;
using ACME.LearningCenterPlatform.API.Discipline.Domain.Repositories;
using ACME.LearningCenterPlatform.API.Discipline.Domain.Services;
using ACME.LearningCenterPlatform.API.Shared.Domain.Repositories;

namespace ACME.LearningCenterPlatform.API.Discipline.Application.Internal.CommandServices;

public class AthleticDisciplineCommandService(
    IAthleticDisciplineRepository athleticDisciplineRepository,
    IUnitOfWork unitOfWork) : IAthleticDisciplineCommandService
{
    public async Task<AthleticDiscipline> Handle(CreateAthleticDisciplineCommand command)
    {
        if (await athleticDisciplineRepository.ExistsByNameSportAndMode(command.Name, command.SportId, command.Mode))
            throw new Exception("Athletic with the same name sport id and model already exits");
        var athleticDiscipline = new AthleticDiscipline(command);
        await athleticDisciplineRepository.AddAsync(athleticDiscipline);
        await unitOfWork.CompleteAsync();
        return athleticDiscipline;
    }
}