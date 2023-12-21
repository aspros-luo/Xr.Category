using Aspros.SaaS.System.Application.Command;
using Aspros.SaaS.System.Application.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using System.Collections.Concurrent;

namespace Aspros.SaaS.System.WebApi.Controllers
{
    [ApiController]
    [Route("system")]
    public class TenantPackageController(IMediator mediator) : Controller
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        [Route("tenant.package.created")]
        public async Task<IActionResult> Created(TenantPackageCreateCommand cmd)
        {
            var result = await _mediator.Send(cmd);
            return Ok(new { data = result, is_successd = true });
        }

        [HttpPut]
        [Route("tenant.package.del")]
        public async Task<IActionResult> Del(TenantPackageDelCommand cmd)
        {
            var result = await _mediator.Send(cmd);
            return Ok(new { data = result, is_successd = true });
        }

        [HttpPost]
        [Route("tenant.package.modify")]
        public async Task<IActionResult> Modify(TenantPackageModifyCommand cmd)
        {
            var result = await _mediator.Send(cmd);
            return Ok(new { data = result, is_successd = true });
        }

        [HttpGet]
        [Route("tenant.package.query.list")]
        public async Task<IActionResult> List([FromQuery] TenantPackageListQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(new { data = result, is_successd = true });
        }
        public static readonly object _lock = new();
        public static Queue<string> queue = new();//队列
        [HttpGet]
        [Route("tenant.package.query.Test")]
        public async Task<IActionResult> Test()
        {
            var list = new string[] {
                "1011:1012:-1:-1:-1:-1:-1:-1:-1:-1:",
                "1011:1013:-1:-1:-1:-1:-1:-1:-1:-1:",
                "1011:1014:-1:-1:-1:-1:-1:-1:-1:-1:",
                "1011:1015:-1:-1:-1:-1:-1:-1:-1:-1:",
                "1011:1016:-1:-1:-1:-1:-1:-1:-1:-1:",
                "1011:1017:-1:-1:-1:-1:-1:-1:-1:-1:",
                "1011:1018:-1:-1:-1:-1:-1:-1:-1:-1:",
                "1011:1019:-1:-1:-1:-1:-1:-1:-1:-1:"};
            await Parallel.ForEachAsync(list, new ParallelOptions() { MaxDegreeOfParallelism = 8 }, async (x, _) =>
            {
                lock (_lock)
                {
                    queue.Enqueue(x);
                }
                await Task.FromResult(0);
            }
           );
            foreach (var item in queue)
            {
                await Console.Out.WriteLineAsync(item);
            }
            return Ok(new { data = 0, is_successd = true });
        }
    }
}
