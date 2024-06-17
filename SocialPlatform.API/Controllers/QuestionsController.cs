using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialPlatform.Application.DTO;
using SocialPlatform.Application.DTO.Create;
using SocialPlatform.Application.DTO.Read;
using SocialPlatform.Application.DTO.Update;
using SocialPlatform.Application.UseCases.Questions;
using SocialPlatform.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly UseCaseHandler _handler;

        public QuestionsController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        /// <summary>
        /// Endpoint for retrieving questions.
        /// </summary>
        /// <param name="search">Search criteria for questions.</param>
        /// <param name="query">Query for retrieving questions.</param>
        /// <returns>OK response with questions.</returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get([FromQuery] QuestionPagedSearchDTO search, [FromServices] IGetQuestionsQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        /// <summary>
        /// Endpoint for retrieving a question by ID.
        /// </summary>
        /// <param name="id">ID of the question to retrieve.</param>
        /// <param name="query">Query for retrieving the question.</param>
        /// <returns>OK response with the question.</returns>
        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult GetById(int id, [FromServices] IGetQuestionQuery query)
        {
            var question = _handler.HandleQuery(query, id);
            return Ok(question);
        }

        /// <summary>
        /// Endpoint for creating a new question.
        /// </summary>
        /// <param name="data">Data for creating the question.</param>
        /// <param name="command">Command for creating the question.</param>
        /// <returns>Status code 201 if successful.</returns>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CreateQuestionDTO data, [FromServices] ICreateQuestionCommand command)
        {
            _handler.HandleCommand(command, data);
            return StatusCode(201);
        }

        /// <summary>
        /// Endpoint for updating an existing question.
        /// </summary>
        /// <param name="id">ID of the question to update.</param>
        /// <param name="data">Data for updating the question.</param>
        /// <param name="command">Command for updating the question.</param>
        /// <returns>Status code 204 if successful.</returns>
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] UpdateQuestionDTO data, [FromServices] IUpdateQuestionCommand command)
        {
            data.Id = id;
            _handler.HandleCommand(command, data);
            return NoContent();
        }

        /// <summary>
        /// Endpoint for deleting a question by ID.
        /// </summary>
        /// <param name="id">ID of the question to delete.</param>
        /// <param name="command">Command for deleting the question.</param>
        /// <returns>Status code 204 if successful.</returns>
        [HttpDelete("{id}")]
        //[Authorize]
        public IActionResult Delete(int id, [FromServices] IDeleteQuestionCommand command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        }
    }
}

