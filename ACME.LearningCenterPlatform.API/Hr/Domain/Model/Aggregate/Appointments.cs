using ACME.LearningCenterPlatform.API.Hr.Domain.Model.Commands;
using ACME.LearningCenterPlatform.API.Hr.Domain.Model.ValueObjects;

namespace ACME.LearningCenterPlatform.API.Hr.Domain.Model.Aggregate;

public partial class Appointments
{
    public int Id { get; set; }
    public string PatientName { get; set; }
    public string DoctorName { get; set; }
    public string Email { get; set; }
    public ESpecialty Specialty { get; set; }
    public DateTime Date { get; set; }
    public string Time { get; set; }

    protected Appointments()
    {
        PatientName = string.Empty;
        DoctorName = string.Empty;
        Email = string.Empty;
        Specialty = ESpecialty.GeneralMedicine;
        Date = DateTime.MinValue;
        Time = string.Empty;
    }

    public Appointments(CreateAppointmentsCommand command)
    {
        PatientName = command.PatientName;
        DoctorName = command.DoctorName;
        Email = command.Email;
        Specialty = command.Specialty;
        Date = command.Date;
        Time = command.Time;
    }
}