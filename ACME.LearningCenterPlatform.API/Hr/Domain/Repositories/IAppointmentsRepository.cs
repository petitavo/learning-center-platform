using ACME.LearningCenterPlatform.API.Hr.Domain.Model.Aggregate;
using ACME.LearningCenterPlatform.API.Shared.Domain.Repositories;

namespace ACME.LearningCenterPlatform.API.Hr.Domain.Repositories;

public interface IAppointmentsRepository : IBaseRepository<Appointments>
{
    
    Task<bool> ExistsByDoctorNameAndEmailAndDateAndTimeAsync(string doctorName, string email, DateTime date, string time);
    
}