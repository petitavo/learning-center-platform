using ACME.LearningCenterPlatform.API.CRM.Domain.Model.Aggregate;
using ACME.LearningCenterPlatform.API.CRM.Domain.Repositories;
using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ACME.LearningCenterPlatform.API.CRM.Infrastructure.Persistence.EFC.Repositories;

public class ManagerRepository(AppDbContext context) : BaseRepository<Manager>(context), IManagerRepository
{
    
    public async Task<bool> existsManagerByFirstNameAndLastNameAsync(string firstName, string lastName)
    {
        return await Context.Set<Manager>().AnyAsync(manager => manager.FirstName == firstName && manager.LastName == lastName);
    }
}