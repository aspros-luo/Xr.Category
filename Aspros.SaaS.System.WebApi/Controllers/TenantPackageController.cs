using Aspros.SaaS.System.Application.Command;
using Aspros.SaaS.System.Application.Query;
using Aspros.SaaS.System.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using System.Collections.Concurrent;

namespace Aspros.SaaS.System.WebApi.Controllers
{
    [ApiController]
    [Route("system")]
    public class TenantPackageController(IMediator mediator, IDistributedCache distributedCache) : Controller
    {
        private readonly IMediator _mediator = mediator;
        private readonly IDistributedCache _distributedCache = distributedCache;

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

        [HttpGet]
        [Route("tenant.package.redis.test")]
        [Permission("system:user:query1", "2,101")]
        public async Task<IActionResult> RedisTest(string a)
        {
            await _distributedCache.SetStringAsync($"{a}-key", a);

             var result =await _distributedCache.GetStringAsync($"{a}-key");
            return Ok(result);
        }
    }
}
