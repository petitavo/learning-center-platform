using System.Net.Mime;
using ACME.LearningCenterPlatform.API.Subscriptions.Domain.Services;
using ACME.LearningCenterPlatform.API.Subscriptions.Interfaces.REST.Resources;
using ACME.LearningCenterPlatform.API.Subscriptions.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ACME.LearningCenterPlatform.API.Subscriptions.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Plan")]
public class PlanController(
    IPlanCommandService planCommandService
) : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a plan",
        Description = "Create a plan with the specified name, max users, default status, and monetization strategy",
        OperationId = "CreatePlan")]
    public async Task<ActionResult> CreatePlan([FromBody] CreatePlanResource resource)
    {
        var createPlanCommand =
            CreatePlanCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await planCommandService.Handle(createPlanCommand);
        var planResource = PlanResourceFromEntityAssembler.ToResourceFromEntity(result);
        return CreatedAtAction(nameof(CreatePlan), new { id = planResource.Id }, planResource);
    }
}