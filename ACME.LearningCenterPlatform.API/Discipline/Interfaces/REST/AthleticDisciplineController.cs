using System.Net.Mime;
using ACME.LearningCenterPlatform.API.Discipline.Domain.Services;
using ACME.LearningCenterPlatform.API.Discipline.Interfaces.REST.Resources;
using ACME.LearningCenterPlatform.API.Discipline.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ACME.LearningCenterPlatform.API.Discipline.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Athletic Discipline")]
public class AthleticDisciplineController(
    IAthleticDisciplineCommandService athleticDisciplineCommandService
) : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create an athletic discipline ",
        Description = "Create a athletic discipline with the specified name, sport id and mode",
        OperationId = "CreateAthleticDiscipline")]
    [SwaggerResponse(StatusCodes.Status201Created, "The soccer player was created", typeof(AthleticDisciplineResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The soccer player could not be created")]
    public async Task<ActionResult> CreateAthleticDiscipline([FromBody] CreateAthleticDisciplineResource resource)
    {
        var createAthleticDisciplineCommand =
            CreateAthleticDisciplineFromResourceAssembler.ToCommandFromResource(resource);
        var result = await athleticDisciplineCommandService.Handle(createAthleticDisciplineCommand);
        var athleticDisciplineResource = AthleticDisciplineResourceFromEntityAssembles.ToResourceFromEntity(result);
        return CreatedAtAction(nameof(CreateAthleticDiscipline), new { id = athleticDisciplineResource.Id },
            athleticDisciplineResource);
    }
}