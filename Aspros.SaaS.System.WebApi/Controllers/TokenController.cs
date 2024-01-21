using Aspros.SaaS.System.Application.Command;
using Aspros.SaaS.System.Application.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aspros.SaaS.System.WebApi.Controllers
{
    [ApiController]
    [Route("system")]
    public class TokenController(IMediator mediator) : Controller
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("user.login")]
        public async Task<IActionResult> Login(UserLoginCommand cmd)
        {
            return Ok(await _mediator.Send(cmd));
        }

        [Authorize]
        [HttpPost("token.refresh")]
        public async Task<IActionResult> Refesh(RefreshTokenCommand cmd)
        {
            return Ok(await _mediator.Send(cmd));
        }


    }
}
