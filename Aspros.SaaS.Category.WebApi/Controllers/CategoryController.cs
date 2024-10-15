
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aspros.SaaS.System.WebApi.Controllers
{
    [ApiController]
    [Route("category")]
    public class CategoryController (IMediator mediator) : Controller
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        [Route("demo.test")]
        [Authorize]
        public async Task<IActionResult> DemoTest()
        {
            return Ok(DateTime.Now);
        }
    }
}
