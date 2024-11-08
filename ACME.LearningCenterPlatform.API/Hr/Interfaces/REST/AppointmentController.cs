using System.Net.Mime;
using ACME.LearningCenterPlatform.API.Hr.Domain.Services;
using ACME.LearningCenterPlatform.API.Hr.Interfaces.REST.Resources;
using ACME.LearningCenterPlatform.API.Hr.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace ACME.LearningCenterPlatform.API.Hr.Interfaces.REST;

[ApiController]
[Route("api/v1/appointments")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Appointments")]
public class AppointmentController(
    IAppointmentCommandService appointmentCommandService
    ) : ControllerBase
{
        
        [HttpPost]
        public async Task<ActionResult> CreateAppointment([FromBody] CreateAppointmentResource resource)
        {
            var createAppointmentCommand =
                CreateAppointmentFromResourceAssembler.ToCommandFromResource(resource);
            var result = await appointmentCommandService.Handle(createAppointmentCommand);
            var appointmentResource = AppointmentResourceFromEntityAssembler.ToResourceFromEntity(result);
            return CreatedAtAction(nameof(CreateAppointment), new { id = appointmentResource.Id }, appointmentResource);
        }
    
}