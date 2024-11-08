using System.ComponentModel.DataAnnotations;
using ACME.LearningCenterPlatform.API.Kr.Domain.Model.ValueObjects;

namespace ACME.LearningCenterPlatform.API.Kr.Interfaces.REST.Resources;

public record CreateKingrentalResource(
    string Name,
    [EnumDataType(typeof(EDepartment))]
    int DepartmentId,
    string DesiredJobTitle,
    string ResumeUrl
    );