using ACME.LearningCenterPlatform.API.SoccerPlayer.Domain.Model.Commands;
using ACME.LearningCenterPlatform.API.SoccerPlayer.Domain.Model.ValueObjects;

namespace ACME.LearningCenterPlatform.API.SoccerPlayer.Domain.Model.Aggregate;

public partial class SoccerPlayer
{
    protected SoccerPlayer()
    {
        Country = int.MinValue;
        Name = string.Empty;
        Position = EPosition.Goalkeeper;
        BirthDate = DateTime.MinValue;
    }


    public SoccerPlayer(CreateSoccerPlayerCommand command)
    {
        Name = command.Name;
        Country = command.Country;
        Position = command.Position;
        BirthDate = command.BirthDate;
    }

    public int Id { get; }
    public string Name { get; private set; }
    public int Country { get; private set; }
    public EPosition Position { get; private set; }
    public DateTime BirthDate { get; private set; }
}