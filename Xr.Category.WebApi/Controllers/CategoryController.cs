
using Aspros.Base.Framework.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Xr.Category.Application;

namespace Xr.System.WebApi.Controllers
{
    [ApiController]
    [Route("category")]
    public class CategoryController (IMediator mediator) : WebApiController
    {
        private readonly IMediator _mediator = mediator;

        /// <summary>
        /// 新增类目
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("action.category.add")]
        public async Task<IActionResult> ActionCategoryAdd([FromBody] CategoryAddCmd cmd)
        {
            var result = await _mediator.Send(cmd);
            return Success(result);
        }

        /// <summary>
        /// 修改类目
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut("action.category.modify")]
        public async Task<IActionResult> ActionCategoryModify([FromBody] CategoryModifyCmd cmd)
        {
            var result = await _mediator.Send(cmd);
            return Success(result);
        }

        /// <summary>
        /// 查看类目详情
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("action.category.detail.query")]
        public async Task<IActionResult> ActionCategoryDetailQuery([FromQuery] CategoryDetailQuery query)
        {
            var data  = await _mediator.Send(query);
            return Success(data);
        }
    }
}
