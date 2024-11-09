namespace ACME.LearningCenterPlatform.API.CRM.Interfaces.REST.Resources;

public record ManagerResource(
    int Id,
    string VeterinaryCampaignManagerId,
    string FirstName, 
    string LastName,
    string? Status, 
    DateTime? ContactedAt, 
    DateTime? ApprovedAt, 
    DateTime? ReportedAt);
    
    
    
