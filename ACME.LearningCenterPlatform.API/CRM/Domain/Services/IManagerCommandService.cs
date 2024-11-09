using ACME.LearningCenterPlatform.API.CRM.Domain.Model.Aggregate;
using ACME.LearningCenterPlatform.API.CRM.Domain.Model.Commands;

namespace ACME.LearningCenterPlatform.API.CRM.Domain.Services;

public interface IManagerCommandService
{
    Task<Manager?> Handle(CreateManagerCommand command);
    
}