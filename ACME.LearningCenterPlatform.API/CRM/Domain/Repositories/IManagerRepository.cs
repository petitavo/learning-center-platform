using ACME.LearningCenterPlatform.API.CRM.Domain.Model.Aggregate;
using ACME.LearningCenterPlatform.API.Shared.Domain.Repositories;

namespace ACME.LearningCenterPlatform.API.CRM.Domain.Repositories;

public interface IManagerRepository : IBaseRepository<Manager>
{
    Task<bool> existsManagerByFirstNameAndLastNameAsync(string firstName, string lastName);
}