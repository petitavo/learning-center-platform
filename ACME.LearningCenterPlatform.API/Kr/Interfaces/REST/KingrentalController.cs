using System.Net.Mime;
using ACME.LearningCenterPlatform.API.Kr.Domain.Services;
using ACME.LearningCenterPlatform.API.Kr.Interfaces.REST.Resources;
using ACME.LearningCenterPlatform.API.Kr.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ACME.LearningCenterPlatform.API.Kr.Interfaces.REST;

[ApiController]
[Route("api/v1/join-request")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Join-request")]
public class KingrentalController(
    IKingrentalCommandService kingrentalCommandService
    ) : ControllerBase
{
    
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a kingrental",
        Description = "Create a kingrental with the specified name, max users, default status, and monetization strategy",
        OperationId = "CreateKingrental")]
    
    public async Task<ActionResult> CreateKingrental([FromBody] CreateKingrentalResource resource)
    {
        var createKingrentalCommand =
            CreateKingrentalCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await kingrentalCommandService.Handle(createKingrentalCommand);
        var kingrentalResource = KingrentalResourceFromEntityAssembler.ToResourceFromEntity(result);
        return CreatedAtAction(nameof(CreateKingrental), new { id = kingrentalResource.Id }, kingrentalResource);
    }
    
}