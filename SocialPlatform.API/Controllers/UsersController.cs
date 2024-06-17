using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialPlatform.API.DTO;
using SocialPlatform.Application.DTO;
using SocialPlatform.Application.DTO.Create;
using SocialPlatform.Application.DTO.Read;
using SocialPlatform.Application.DTO.Update;
using SocialPlatform.Application.UseCases.Users;
using SocialPlatform.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UseCaseHandler _handler;
        public UsersController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        /// <summary>
        /// Endpoint for retrieving users.
        /// </summary>
        /// <param name="search">Search parameters for filtering users.</param>
        /// <param name="query">Query for retrieving users.</param>
        /// <returns>List of users.</returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get([FromQuery] UserPagedSearchDTO search, [FromServices] IGetUsersQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }


        /// <summary>
        /// Endpoint for retrieving a user by ID.
        /// </summary>
        /// <param name="id">ID of the user to retrieve.</param>
        /// <param name="query">Query for retrieving the user.</param>
        /// <returns>The user with the specified ID.</returns>
        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult GetById(int id, [FromServices] IGetUserQuery query)
        {
            var user = _handler.HandleQuery(query, id);
            return Ok(user);
        }

        /// <summary>
        /// Endpoint for creating a new user.
        /// </summary>
        /// <param name="data">Data for creating the user.</param>
        /// <param name="command">Command for creating the user.</param>
        /// <returns>Status code 201 if successful.</returns>
        [HttpPost]
        public IActionResult Post([FromForm] CreateUserAvatarDTO data, [FromServices] ICreateUserCommand command)
        {
            if (data.File != null)
            {
                var extension = Path.GetExtension(data.File.FileName);

                if (!allowedExtensions.Contains(extension))
                {
                    return new UnsupportedMediaTypeResult();
                }

                var fileName = Guid.NewGuid().ToString() + extension;

                var savePath = Path.Combine("wwwroot", "images", fileName);

                using var fs = new FileStream(savePath, FileMode.Create);

                data.File.CopyTo(fs);

                data.Avatar = fileName;
            }
            _handler.HandleCommand(command, data);
            return StatusCode(201);
        }

        /// <summary>
        /// Endpoint for updating a user by ID.
        /// </summary>
        /// <param name="id">ID of the user to update.</param>
        /// <param name="data">Data for updating the user.</param>
        /// <param name="command">Command for updating the user.</param>
        /// <returns>Status code 204 if successful.</returns>
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] UpdateUserDTO data, [FromServices] IUpdateUserCommand command)
        {
            data.Id = id;
            _handler.HandleCommand(command, data);
            return NoContent();
        }

        /// <summary>
        /// Endpoint for updating a use cases for user by ID.
        /// </summary>
        /// <param name="id">ID of the user to update.</param>
        /// <param name="command">Command for updating the user use cases.</param>
        /// <returns>Status code 204 if successful.</returns>
        [HttpPut("{id}/Access")]
        [Authorize]
        public IActionResult ModifyAccess(int id, [FromBody] UpdateUserAccessDTO dto,
                                                  [FromServices] IUpdateUserAccessCommand command)
        {
            dto.UserId = id;
            _handler.HandleCommand(command, dto);
            return NoContent();
        }

        /// <summary>
        /// Endpoint for deleting a user by ID.
        /// </summary>
        /// <param name="id">ID of the user to delete.</param>
        /// <param name="command">Command for deleting the user.</param>
        /// <returns>Status code 204 if successful.</returns>
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromServices] IDeleteUserCommand command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        }

        private static IEnumerable<string> allowedExtensions = new List<string>
        {
            ".jpg", ".jpeg", ".png"
        };
    }
}

