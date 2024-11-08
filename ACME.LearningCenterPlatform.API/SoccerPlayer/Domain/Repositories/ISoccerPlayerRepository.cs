using ACME.LearningCenterPlatform.API.Shared.Domain.Repositories;

namespace ACME.LearningCenterPlatform.API.SoccerPlayer.Domain.Repositories;

public interface ISoccerPlayerRepository : IBaseRepository<Model.Aggregate.SoccerPlayer>
{
    Task<bool> ExistsByNameAndCountryAsync(string name, int country);
}