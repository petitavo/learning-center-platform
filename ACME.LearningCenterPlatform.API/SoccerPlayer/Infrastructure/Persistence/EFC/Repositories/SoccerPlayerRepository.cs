using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using ACME.LearningCenterPlatform.API.SoccerPlayer.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ACME.LearningCenterPlatform.API.SoccerPlayer.Infrastructure.Persistence.EFC.Repositories;

public class SoccerPlayerRepository(AppDbContext context) :
    BaseRepository<Domain.Model.Aggregate.SoccerPlayer>(context), ISoccerPlayerRepository
{
    public async Task<bool> ExistsByNameAndCountryAsync(string name, int country)
    {
        return await Context.Set<Domain.Model.Aggregate.SoccerPlayer>()
            .AnyAsync(player => player.Name == name && player.Country == country);
    }
}