using ACME.LearningCenterPlatform.API.Discipline.Domain.Model.ValueObjects;
using ACME.LearningCenterPlatform.API.Hr.Domain.Model.Commands;
using ACME.LearningCenterPlatform.API.Hr.Domain.Model.ValueObjects;
using ACME.LearningCenterPlatform.API.Hr.Interfaces.REST.Resources;

namespace ACME.LearningCenterPlatform.API.Hr.Interfaces.REST.Transform;

public static class CreateAppointmentFromResourceAssembler
{
    public static CreateAppointmentsCommand ToCommandFromResource(CreateAppointmentResource resource)
    {
        return new CreateAppointmentsCommand(
            resource.DoctorName,
            resource.PatientName,
            resource.Email,
            Enum.Parse<ESpecialty>(resource.Specialty.ToString(), true),
            resource.Date,
            resource.Time);
            
    }
}