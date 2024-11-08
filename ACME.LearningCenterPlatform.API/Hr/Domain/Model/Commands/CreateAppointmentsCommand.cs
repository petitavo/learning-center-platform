using ACME.LearningCenterPlatform.API.Hr.Domain.Model.ValueObjects;

namespace ACME.LearningCenterPlatform.API.Hr.Domain.Model.Commands;

public record CreateAppointmentsCommand(string PatientName, string DoctorName, string Email, ESpecialty Specialty, DateTime Date, string Time);