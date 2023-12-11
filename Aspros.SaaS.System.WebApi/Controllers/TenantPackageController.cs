using Aspros.SaaS.System.Application.Command;
using Aspros.SaaS.System.Application.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Aspros.SaaS.System.WebApi.Controllers
{
    [ApiController]
    [Route("tenant.package")]
    public class TenantPackageController(IMediator mediator) : Controller
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        [Route("created")]
        public async Task<IActionResult> Created(TenantPackageCreateCommand cmd)
        {
            var result = await _mediator.Send(cmd);
            return Ok(new { data = result, is_successd = true });
        }

        [HttpGet]
        [Route("query.list")]
        public async Task<IActionResult> List([FromQuery] TenantPackageListQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(new { data = result, is_successd = true });
        }
    }
}
