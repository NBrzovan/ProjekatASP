using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialPlatform.Application.DTO;
using SocialPlatform.Application.DTO.Read;
using SocialPlatform.Application.UseCases.Logs;
using SocialPlatform.Application.UseCases.Users;
using SocialPlatform.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly UseCaseHandler _handler;

        public LogsController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        /// <summary>
        /// Endpoint for retrieving audit logs.
        /// </summary>
        /// <returns>OK response.</returns>
        [HttpGet("Audit")]
        [Authorize]
        public IActionResult GetAuditLogs([FromQuery] UseCaseLogsPagedSearchDTO search, [FromServices] IGetUseCaseLogsQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        /// <summary>
        /// Endpoint for retrieving a specific error by ID.
        /// </summary>
        /// <param name="id">ID of error to retrieve.</param>
        /// <param name="query">Query for retrieving the error.</param>
        /// <returns>The error informations with the specified ID.</returns>
        [HttpGet("Error/{id}")]
        [Authorize]
        public IActionResult GetErrorById(Guid id, [FromServices] IGetErrorLogQuery query)
        {
            var user = _handler.HandleQuery(query, id);
            return Ok(user);
        }
    }
}

