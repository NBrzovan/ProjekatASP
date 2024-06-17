using Microsoft.AspNetCore.Mvc;
using SocialPlatform.Application.DTO.Create;
using SocialPlatform.Implementation.UseCases.Followings;
using SocialPlatform.Implementation;
using SocialPlatform.Application.UseCases.Followings;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowingsController : ControllerBase
    {
        private readonly UseCaseHandler _handler;

        public FollowingsController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        /// <summary>
        /// Endpoint for creating a new follow relationship.
        /// </summary>
        /// <param name="data">Data for creating the follow relationship.</param>
        /// <param name="command">Command for creating the follow relationship.</param>
        /// <returns>Status code 201 if successful.</returns>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CreateFollowDTO data, [FromServices] ICreateFollowCommand command)
        {
            _handler.HandleCommand(command, data);
            return StatusCode(201);
        }

        /// <summary>
        /// Endpoint for deleting a follow relationship by ID.
        /// </summary>
        /// <param name="id">ID of the follow relationship to delete.</param>
        /// <param name="command">Command for deleting the follow relationship.</param>
        /// <returns>Status code 204 if successful.</returns>
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromServices] IDeleteFollowCommand command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        }


        /// <summary>
        /// Endpoint for following a community.
        /// </summary>
        /// <param name="data">Data for following the community.</param>
        /// <param name="command">Command for following the community.</param>
        /// <returns>Status code 201 if successful.</returns>
        [HttpPost("FollowCommunity")]
        [Authorize]
        public IActionResult FollowCommunity([FromBody] CreateFollowCommunityDTO data, [FromServices] ICreateFollowCommunityCommand command)
        {
            _handler.HandleCommand(command, data);
            return StatusCode(201);
        }

        /// <summary>
        /// Endpoint for unfollowing a community.
        /// </summary>
        /// <param name="data">ID of the community to unfollow.</param>
        /// <param name="command">Command for unfollowing the community.</param>
        /// <returns>Status code 204 if successful.</returns>
        [HttpDelete("UnfollowCommunity")]
        [Authorize]
        public IActionResult UnfollowCommunity(int data, [FromServices] IDeleteFollowCommunityCommand command)
        {
            _handler.HandleCommand(command, data);
            return NoContent();
        }
    }
}

