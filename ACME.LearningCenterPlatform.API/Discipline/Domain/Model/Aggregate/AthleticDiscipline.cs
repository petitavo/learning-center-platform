using ACME.LearningCenterPlatform.API.Discipline.Domain.Model.Commands;
using ACME.LearningCenterPlatform.API.Discipline.Domain.Model.ValueObjects;

namespace ACME.LearningCenterPlatform.API.Discipline.Domain.Model.Aggregate;

public partial class AthleticDiscipline
{
    public AthleticDiscipline()
    {
        Name = string.Empty;
        SportId = string.Empty;
        Mode = EMode.Individual;
    }

    public AthleticDiscipline(CreateAthleticDisciplineCommand command)
    {
        Name = command.Name;
        SportId = command.SportId;
        Mode = command.Mode;
    }

    public int Id { get; }
    public string Name { get; private set; }
    public string SportId { get; private set; }
    public EMode Mode { get; private set; }
}