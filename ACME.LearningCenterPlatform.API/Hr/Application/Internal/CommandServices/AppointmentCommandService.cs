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
    /// <summary>
    /// Create a new appointment
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<Appointments> Handle(CreateAppointmentsCommand command)
    {
        var appointment = new Appointments(command);
        
        if(await appointmentsRepository.ExistsByDoctorNameAndEmailAndDateAndTimeAsync(command.DoctorName, command.Email, command.Date, command.Time))
            throw new Exception("La Vane esta ocupada en ese horario");
        
        if (!appointment.IsValidSpecialty(command.Specialty)) throw new Exception("The speciality is not valid.");
        
        
        await appointmentsRepository.AddAsync(appointment);
        await unitOfWork.CompleteAsync();
        return appointment;
    }
    
    

  
    
    
}