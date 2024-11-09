using ACME.LearningCenterPlatform.API.CRM.Domain.Model.Aggregate;
using ACME.LearningCenterPlatform.API.CRM.Domain.Model.Queries;

namespace ACME.LearningCenterPlatform.API.CRM.Domain.Services;

public interface IManagerQueryService
{ 
    Task<IEnumerable<Manager>> Handle(GetAllManagerQuery query); 
    Task<Manager?> Handle(GetManagerByIdQuery query);
}