using ACME.LearningCenterPlatform.API.Hr.Domain.Model.Aggregate;
using ACME.LearningCenterPlatform.API.Hr.Domain.Model.Commands;

namespace ACME.LearningCenterPlatform.API.Hr.Domain.Services;

public interface IAppointmentCommandService
{
    public Task<Appointments> Handle(CreateAppointmentsCommand command);
}