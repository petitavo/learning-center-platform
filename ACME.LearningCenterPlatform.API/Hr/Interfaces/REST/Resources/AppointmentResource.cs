using ACME.LearningCenterPlatform.API.Hr.Domain.Model.ValueObjects;

namespace ACME.LearningCenterPlatform.API.Hr.Interfaces.REST.Resources;

public record AppointmentResource(int Id, string PatientName, string DoctorName, string Email, string? Specialty, DateTime? Date, string Time);