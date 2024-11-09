using ACME.LearningCenterPlatform.API.Hr.Domain.Model.ValueObjects;

namespace ACME.LearningCenterPlatform.API.Hr.Domain.Model.Commands;

public record CreateAppointmentsCommand(string PatientName, string DoctorName, string Email, string Specialty, DateTime Date, string Time);