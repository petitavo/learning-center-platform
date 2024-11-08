using ACME.LearningCenterPlatform.API.Kr.Domain.Model.ValueObjects;

namespace ACME.LearningCenterPlatform.API.Kr.Interfaces.REST.Resources;

public record KingrentalResource(int Id,string Name, EDepartment DepartmentId, string DesiredJobTitle, string ResumeUrl);