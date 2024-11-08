using ACME.LearningCenterPlatform.API.Kr.Domain.Model.Aggregate;
using ACME.LearningCenterPlatform.API.Kr.Domain.Model.Commands;
using ACME.LearningCenterPlatform.API.Kr.Domain.Repositories;
using ACME.LearningCenterPlatform.API.Kr.Domain.Services;
using ACME.LearningCenterPlatform.API.Shared.Domain.Repositories;

namespace ACME.LearningCenterPlatform.API.Kr.Application.Internal.CommandServices;

public class KingrentalCommandService(
    IKingrentalRepository kingrentalRepository,
    IUnitOfWork unitOfWork) : IKingrentalCommandService
    
{
    public async Task<Kingrentals> Handle(CreateKingrentalCommand command)
    {
        if (await kingrentalRepository.ExistsByNameAndDepartmentIdAsync(command.Name, command.DepartmentId))
            throw new Exception("Kingrental with the same name and country already exists");
        var kingrental = new Kingrentals(command);
        await kingrentalRepository.AddAsync(kingrental);
        await unitOfWork.CompleteAsync();
        return kingrental;
    }
}