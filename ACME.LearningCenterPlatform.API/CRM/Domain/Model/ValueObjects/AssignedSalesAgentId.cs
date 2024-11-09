namespace ACME.LearningCenterPlatform.API.CRM.Domain.Model.ValueObjects;

public class AssignedSalesAgentId
{
    public Guid Value { get; private set; }

    public AssignedSalesAgentId()
    {
        Value = Guid.NewGuid();
    }

    public AssignedSalesAgentId(string value)
    {
        Value = Guid.Parse(value);
    }

    public override string ToString()
    {
        return Value.ToString();
    }
    
}