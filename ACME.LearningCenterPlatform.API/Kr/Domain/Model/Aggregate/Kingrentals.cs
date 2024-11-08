using ACME.LearningCenterPlatform.API.Kr.Domain.Model.Commands;
using ACME.LearningCenterPlatform.API.Kr.Domain.Model.ValueObjects;

namespace ACME.LearningCenterPlatform.API.Kr.Domain.Model.Aggregate;

public partial class Kingrentals
{
    public int Id { get; set; }
    public string Name { get; set; }
    public EDepartment DepartmentId { get; set; }
    public string DesiredJobTitle { get; set; }
    public string ResumeUrl { get; set; }

    protected Kingrentals()
    {
        Name = string.Empty;
        DepartmentId = EDepartment.DriversOrLogisticSupport;
        DesiredJobTitle = string.Empty;
        ResumeUrl = string.Empty;
    }

    public Kingrentals(CreateKingrentalCommand command)
    {
        Name = command.Name;
        DepartmentId = command.DepartmentId;
        DesiredJobTitle = command.DesiredJobTitle;
        ResumeUrl = command.ResumeUrl;
        
    }
    
}