using ACME.LearningCenterPlatform.API.Shared.Domain.Repositories;
using ACME.LearningCenterPlatform.API.Subscriptions.Domain.Model.Aggregate;
using ACME.LearningCenterPlatform.API.Subscriptions.Domain.Model.Commands;
using ACME.LearningCenterPlatform.API.Subscriptions.Domain.Model.ValueObjects;
using ACME.LearningCenterPlatform.API.Subscriptions.Domain.Repositories;
using ACME.LearningCenterPlatform.API.Subscriptions.Domain.Services;

namespace ACME.LearningCenterPlatform.API.Subscriptions.Application.Internal.CommandServices;

public class PlanCommandService(
    IPlanRepository planRepository,
    IUnitOfWork unitOfWork) : IPlanCommandService
{
    public async Task<Plan> Handle(CreatePlanCommand command)
    {
        if (command.MaxUsers <= 0)
            throw new Exception("El número máximo de usuarios debe ser mayor que cero.");
        if (command.IsDefault != 0 && command.IsDefault != 1)
            throw new Exception("El valor de IsDefault debe ser 0 o 1.");
        if (await planRepository.ExistsByNameAsync(command.Name))
            throw new Exception("Plan with the same name already exists");
        if (await planRepository.CantRegisterDefaultAsync(command.IsDefault))
            throw new Exception("There is already a default plan");

        var plan = new Plan(command);
        await planRepository.AddAsync(plan);
        await unitOfWork.CompleteAsync();
        return plan;
    }
}