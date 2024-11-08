using ACME.LearningCenterPlatform.API.Hr.Domain.Model.Aggregate;
using ACME.LearningCenterPlatform.API.Hr.Domain.Repositories;
using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ACME.LearningCenterPlatform.API.Hr.Infrastructure.Persistence.EFC.Repositories;

public class AppointmentRepository(AppDbContext context) :
    BaseRepository<Appointments>(context), IAppointmentsRepository
{
    public async Task<bool> ExistsByDoctorNameAndEmailAndDateAndTimeAsync(string doctorName, string email, DateTime date, string time)
    {
        return await Context.Set<Appointments>()
            .AnyAsync(app => app.DoctorName == doctorName && app.Email == email && app.Date == date && app.Time == time);
    }
}