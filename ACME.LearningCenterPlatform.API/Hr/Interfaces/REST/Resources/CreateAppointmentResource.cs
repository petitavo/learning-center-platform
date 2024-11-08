using System.ComponentModel.DataAnnotations;
using ACME.LearningCenterPlatform.API.Hr.Domain.Model.ValueObjects;

namespace ACME.LearningCenterPlatform.API.Hr.Interfaces.REST.Resources;

public record CreateAppointmentResource(
    string PatientName,
    string DoctorName,
    string Email,
    [EnumDataType(typeof(ESpecialty))] string Specialty,
    DateTime Date,
    string Time
    );