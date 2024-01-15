using Aspros.SaaS.System.Application.Command;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aspros.SaaS.System.WebApi.Controllers
{
    [ApiController]
    [Route("system")]
    public class TenantController (IMediator mediator) : Controller
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        [Route("tenant.created")]
        public async Task<IActionResult> Created(TenantCreateCommand cmd)
        {
            var result = await _mediator.Send(cmd);
            return Ok(new { data = result, is_successd = true });
        }

        [HttpPost]
        [Route("tenant.user.role.confer")]
        [Authorize()]
        public async Task<IActionResult> RoleGived(UserRoleConferCommand cmd)
        {
            var result = await _mediator.Send(cmd);
            return Ok(result);
        }
    }
}
