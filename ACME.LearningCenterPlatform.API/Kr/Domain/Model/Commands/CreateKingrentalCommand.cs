using ACME.LearningCenterPlatform.API.Kr.Domain.Model.ValueObjects;

namespace ACME.LearningCenterPlatform.API.Kr.Domain.Model.Commands;

public record CreateKingrentalCommand(string Name, EDepartment DepartmentId, string DesiredJobTitle, string ResumeUrl);