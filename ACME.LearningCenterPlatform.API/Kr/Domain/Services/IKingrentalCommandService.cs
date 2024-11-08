using ACME.LearningCenterPlatform.API.Kr.Domain.Model.Aggregate;
using ACME.LearningCenterPlatform.API.Kr.Domain.Model.Commands;

namespace ACME.LearningCenterPlatform.API.Kr.Domain.Services;

public interface IKingrentalCommandService
{
    public Task<Kingrentals> Handle(CreateKingrentalCommand command);
}