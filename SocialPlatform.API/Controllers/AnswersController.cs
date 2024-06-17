using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialPlatform.Application.DTO.Create;
using SocialPlatform.Application.DTO.Update;
using SocialPlatform.Application.UseCases.Answers;
using SocialPlatform.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialPlatform.API.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        private readonly UseCaseHandler _handler;

        public AnswersController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        /// <summary>
        /// Endpoint for creating a new answer.
        /// </summary>
        /// <param name="data">Data for creating the answer.</param>
        /// <param name="command">Command for creating the answer.</param>
        /// <returns>Status code 201 if successful.</returns>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CreateAnswerDTO data, [FromServices] ICreateAnswerCommand command)
        {
            _handler.HandleCommand(command, data);
            return StatusCode(201);
        }

        /// <summary>
        /// Endpoint for updating an existing answer.
        /// </summary>
        /// <param name="id">ID of the answer to update.</param>
        /// <param name="data">Data for updating the answer.</param>
        /// <param name="command">Command for updating the answer.</param>
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] UpdateAnswerDTO data, [FromServices] IUpdateAnswerCommand command)
        {
            data.Id = id;
            _handler.HandleCommand(command, data);
            return NoContent();
        }

        /// <summary>
        /// Endpoint for deleting an answer by ID.
        /// </summary>
        /// <param name="id">ID of the answer to delete.</param>
        /// <param name="command">Command for deleting the answer.</param>
        /// <returns>Status code 204 if successful.</returns>
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromServices] IDeleteAnswerCommand command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
