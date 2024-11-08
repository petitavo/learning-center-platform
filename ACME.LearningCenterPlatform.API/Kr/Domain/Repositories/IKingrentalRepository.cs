using ACME.LearningCenterPlatform.API.Kr.Domain.Model.Aggregate;
using ACME.LearningCenterPlatform.API.Kr.Domain.Model.ValueObjects;
using ACME.LearningCenterPlatform.API.Shared.Domain.Repositories;

namespace ACME.LearningCenterPlatform.API.Kr.Domain.Repositories;

public interface IKingrentalRepository : IBaseRepository<Kingrentals>
{
    Task<bool> ExistsByNameAndDepartmentIdAsync(string name, EDepartment departmentId);
}