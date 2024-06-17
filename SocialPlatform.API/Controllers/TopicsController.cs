using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialPlatform.Application.DTO;
using SocialPlatform.Application.DTO.Create;
using SocialPlatform.Application.DTO.Read;
using SocialPlatform.Application.UseCases.Tags;
using SocialPlatform.Application.UseCases.Topics;
using SocialPlatform.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicsController : ControllerBase
    {
        private readonly UseCaseHandler _handler;
        public TopicsController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        /// <summary>
        /// Endpoint for retrieving topics.
        /// </summary>
        /// <param name="search">Search parameters for filtering topics.</param>
        /// <param name="query">Query for retrieving topics.</param>
        /// <returns>List of topics.</returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get([FromQuery] PagedSearchDTO search, [FromServices] IGetTopicsQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }
        /// <summary>
        /// Endpoint for creating a new topic.
        /// </summary>
        /// <param name="data">Data for creating the topic.</param>
        /// <param name="command">Command for creating the topic.</param>
        /// <returns>Status code 201 if successful.</returns>
        [HttpPost]
        //[Authorize]
        public IActionResult Post([FromBody] CreateTopicDTO data, [FromServices] ICreateTopicCommand command)
        {
            _handler.HandleCommand(command, data);
            return StatusCode(201);
        }

        /// <summary>
        /// Endpoint for deleting a topic by ID.
        /// </summary>
        /// <param name="id">ID of the topic to delete.</param>
        /// <param name="command">Command for deleting the topic.</param>
        /// <returns>Status code 204 if successful.</returns>
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromServices] IDeleteTopicCommand command)
        {
            _handler.HandleCommand(command, id);
            return StatusCode(204);
        }
    }
}

