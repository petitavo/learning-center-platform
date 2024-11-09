using ACME.LearningCenterPlatform.API.Hr.Domain.Model.Aggregate;
using ACME.LearningCenterPlatform.API.Hr.Domain.Model.Commands;
using ACME.LearningCenterPlatform.API.Hr.Domain.Repositories;
using ACME.LearningCenterPlatform.API.Hr.Domain.Services;
using ACME.LearningCenterPlatform.API.Shared.Domain.Repositories;

namespace ACME.LearningCenterPlatform.API.Hr.Application.Internal.CommandServices;

public class AppointmentCommandService(
    IAppointmentsRepository appointmentsRepository,
    IUnitOfWork unitOfWork) : IAppointmentCommandService
    
{   
    public async Task<Appointments> Handle(CreateAppointmentsCommand command)
    {
        if(await appointmentsRepository.ExistsByDoctorNameAndEmailAndDateAndTimeAsync(command.DoctorName, command.Email, command.Date, command.Time))
            throw new Exception("La Vane esta ocupada en ese horario");
        var appointment = new Appointments(command);
        await appointmentsRepository.AddAsync(appointment);
        await unitOfWork.CompleteAsync();
        return appointment;
    }
  
    
    
}