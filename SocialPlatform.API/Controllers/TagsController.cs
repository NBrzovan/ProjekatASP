using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialPlatform.Application.DTO.Create;
using SocialPlatform.Application.DTO.Read;
using SocialPlatform.Application.UseCases.Tags;
using SocialPlatform.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly UseCaseHandler _handler;
        public TagsController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        /// <summary>
        /// Endpoint for retrieving tags.
        /// </summary>
        /// <param name="search">Search parameters for filtering tags.</param>
        /// <param name="query">Query for retrieving tags.</param>
        /// <returns>List of tags.</returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get([FromQuery] PagedSearchDTO search, [FromServices] IGetTagsQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        /// <summary>
        /// Endpoint for creating a new tag.
        /// </summary>
        /// <param name="data">Data for creating the tag.</param>
        /// <param name="command">Command for creating the tag.</param>
        /// <returns>Status code 201 if successful.</returns>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CreateTagDTO data, [FromServices] ICreateTagCommand command)
        {
            _handler.HandleCommand(command, data);
            return StatusCode(201);
        }

        /// <summary>
        /// Endpoint for deleting a tag by ID.
        /// </summary>
        /// <param name="id">ID of the tag to delete.</param>
        /// <param name="command">Command for deleting the tag.</param>
        /// <returns>Status code 204 if successful.</returns>
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromServices] IDeleteTagCommand command)
        {
            _handler.HandleCommand(command, id);
            return StatusCode(204);
        }
    }
}


