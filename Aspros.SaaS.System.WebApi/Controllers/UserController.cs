using Aspros.SaaS.System.Application.Command;
using Aspros.SaaS.System.Application.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aspros.SaaS.System.WebApi.Controllers
{
    [ApiController]
    [Route("system")]
    public class UserController(IMediator mediator) : Controller
    {
        private readonly IMediator _mediator = mediator;

        [Authorize]
        [HttpGet("user.permission.query")]
        public async Task<IActionResult> PermissionQuery()
        {
            return Ok(await _mediator.Send(new UserPermissionQuery()));
        }

        [HttpGet]
        [Route("user.permission.valid")]
        public async Task<IActionResult> PermissionValid([FromQuery] UserPermissionValid query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
