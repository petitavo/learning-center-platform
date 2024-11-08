using System.Net.Mime;
using ACME.LearningCenterPlatform.API.SoccerPlayer.Domain.Services;
using ACME.LearningCenterPlatform.API.SoccerPlayer.Interfaces.REST.Resources;
using ACME.LearningCenterPlatform.API.SoccerPlayer.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ACME.LearningCenterPlatform.API.SoccerPlayer.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Soccer Players")]
public class SoccerPlayerController(
    ISoccerPlayerCommandService soccerPlayerCommandService
) : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a soccer player",
        Description = "Create a soccer player with the specified name, country, position, and birth date",
        OperationId = "CreateSoccerPlayer")]
    [SwaggerResponse(StatusCodes.Status201Created, "The soccer player was created", typeof(SoccerPlayerResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The soccer player could not be created")]
    public async Task<ActionResult> CreateSoccerPlayer([FromBody] CreateSoccerPlayerResource resource)
    {
        var createSoccerPlayerCommand =
            CreateSoccerPlayerCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await soccerPlayerCommandService.Handle(createSoccerPlayerCommand);
        var soccerPlayerResource = SoccerPlayerResourceFromEntityAssembler.ToResourceFromEntity(result);
        return CreatedAtAction(nameof(CreateSoccerPlayer), new { id = soccerPlayerResource.Id }, soccerPlayerResource);
    }
}