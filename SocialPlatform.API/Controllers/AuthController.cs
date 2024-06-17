using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialPlatform.API.Core;
using SocialPlatform.API.DTO;
using SocialPlatform.API.Extensions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtTokenCreator _tokenCreator;

        public AuthController(JwtTokenCreator tokenCreator)
        {
            _tokenCreator = tokenCreator;
        }

        /// <summary>
        /// Endpoint for creating a new authentication token.
        /// </summary>
        /// <param name="request">The authentication request.</param>
        /// <returns>The authentication token.</returns>
        [HttpPost]
        public IActionResult Post([FromBody] AuthRequestDTO request)
        {
            string token = _tokenCreator.Create(request.Email, request.Password);

            return Ok(new AuthResponseDTO { Token = token });
        }

        /// <summary>
        /// Endpoint for delete the current authentication token.
        /// </summary>
        /// <param name="storage">The token storage.</param>
        /// <returns>No content if successful.</returns>
        [Authorize]
        [HttpDelete]
        public IActionResult Delete([FromServices] ITokenStorage storage)
        {
            storage.Remove(this.Request.GetTokenId().Value);

            return NoContent();
        }
    }
}
