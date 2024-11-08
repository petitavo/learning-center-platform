using ACME.LearningCenterPlatform.API.Hr.Domain.Model.Aggregate;
using ACME.LearningCenterPlatform.API.Hr.Interfaces.REST.Resources;

namespace ACME.LearningCenterPlatform.API.Hr.Interfaces.REST.Transform;

public static class AppointmentResourceFromEntityAssembler
{
    public static AppointmentResource ToResourceFromEntity(Appointments entity)
    {
        return new AppointmentResource(entity.Id, entity.DoctorName, entity.PatientName, entity.Email,entity.Specialty, entity.Date, entity.Time);
    }
}