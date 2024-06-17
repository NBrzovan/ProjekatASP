using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialPlatform.Application.DTO.Create;
using SocialPlatform.Application.UseCases.Reactions;
using SocialPlatform.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReactionsController : ControllerBase
    {
        private readonly UseCaseHandler _handler;

        public ReactionsController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        /// <summary>
        /// Endpoint for creating a like reaction.
        /// </summary>
        /// <param name="data">Data for creating the like reaction.</param>
        /// <param name="command">Command for creating the like reaction.</param>
        /// <returns>Status code 201 if successful.</returns>
        [HttpPost("Like")]
        [Authorize]
        public IActionResult CreateLike([FromBody] CreateReactionDTO data, [FromServices] ICreateLikeReactionCommand command)
        {
            _handler.HandleCommand(command, data);
            return StatusCode(201);
        }

        /// <summary>
        /// Endpoint for creating a dislike reaction.
        /// </summary>
        /// <param name="data">Data for creating the dislike reaction.</param>
        /// <param name="command">Command for creating the dislike reaction.</param>
        /// <returns>Status code 201 if successful.</returns>
        [HttpPost("Dislike")]
        [Authorize]
        public IActionResult CreateDislike([FromBody] CreateReactionDTO data, [FromServices] ICreateDislikeReactionCommand command)
        {
            _handler.HandleCommand(command, data);
            return StatusCode(201);
        }


        /// <summary>
        /// Endpoint for deleting a reaction by ID.
        /// </summary>
        /// <param name="id">ID of the reaction to delete.</param>
        /// <param name="command">Command for deleting the reaction.</param>
        /// <returns>Status code 204 if successful.</returns>
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromServices] IDeleteReactionCommand command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        }
    }
}

