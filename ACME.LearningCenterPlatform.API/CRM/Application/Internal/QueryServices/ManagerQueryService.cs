using ACME.LearningCenterPlatform.API.CRM.Domain.Model.Aggregate;
using ACME.LearningCenterPlatform.API.CRM.Domain.Model.Queries;
using ACME.LearningCenterPlatform.API.CRM.Domain.Repositories;
using ACME.LearningCenterPlatform.API.CRM.Domain.Services;
using ACME.LearningCenterPlatform.API.Shared.Domain.Repositories;

namespace ACME.LearningCenterPlatform.API.CRM.Application.Internal.QueryServices;

public class ManagerQueryService(IManagerRepository managerRepository, IUnitOfWork unitOfWork) : IManagerQueryService
{
    public async Task<IEnumerable<Manager>> Handle(GetAllManagerQuery query)
    {
        return await managerRepository.ListAsync();
    }

    public async Task<Manager?> Handle(GetManagerByIdQuery query)
    {
        return await managerRepository.FindByIdAsync(query.Id);
    }
    
}