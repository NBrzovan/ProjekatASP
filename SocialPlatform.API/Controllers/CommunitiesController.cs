using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialPlatform.Application.DTO.Create;
using SocialPlatform.Application.DTO.Read;
using SocialPlatform.Application.UseCases.Communities;
using SocialPlatform.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialPlatform.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CommunitiesController : ControllerBase
{
    private readonly UseCaseHandler _handler;
    public CommunitiesController(UseCaseHandler handler)
    {
        _handler = handler;
    }

    /// <summary>
    /// Endpoint for retrieving communities with optional pagination.
    /// </summary>
    /// <param name="search">Search criteria for paginating communities.</param>
    /// <param name="query">Query for retrieving communities.</param>
    /// <returns>List of communities.</returns>
    [HttpGet]
    [AllowAnonymous]
    public IActionResult Get([FromQuery] PagedSearchDTO search, [FromServices] IGetCommunitiesQuery query)
    {
        return Ok(_handler.HandleQuery(query, search));
    }

    /// <summary>
    /// Endpoint for creating a new community.
    /// </summary>
    /// <param name="data">Data for creating the community.</param>
    /// <param name="command">Command for creating the community.</param>
    /// <returns>Status code 201 if successful.</returns>
    [HttpPost]
    [Authorize]
    public IActionResult Post([FromBody] CreateCommunityDTO data, [FromServices] ICreateCommunityCommand command)
    {
        _handler.HandleCommand(command, data);
        return StatusCode(201);
    }

    /// <summary>
    /// Endpoint for deleting a community by ID.
    /// </summary>
    /// <param name="id">ID of the community to delete.</param>
    /// <param name="command">Command for deleting the community.</param>
    /// <returns>Status code 204 if successful.</returns>
    [HttpDelete("{id}")]
    [Authorize]
    public IActionResult Delete(int id, [FromServices] IDeleteCommunityCommand command)
    {
        _handler.HandleCommand(command, id);
        return StatusCode(204);
    }
}
