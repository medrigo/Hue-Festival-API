using HueFestival_OnlineTicket.Core.InterfaceService;
using HueFestival_OnlineTicket.Queries.News.GetAllNews;
using HueFestival_OnlineTicket.Queries.News.GetNewsById;
using HueFestival_OnlineTicket.Queries.User.GetAllUser;
using HueFestival_OnlineTicket.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HueFestival_OnlineTicket.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsService newsService;
        private readonly IMediator _mediator;

        public NewsController(INewsService _newsService, IMediator mediator)
        {
            newsService = _newsService;
            _mediator = mediator;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var res = await _mediator.Send(new GetAllNewsQuery());
            if (res == null)
                return NotFound();
            return Ok(res);
        }
            

        [HttpPost("Add")]
        public async Task<IActionResult> Add(NewsVM_Input input)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            if (await newsService.AddAsync(input))
                return Ok("Successfully");

            return BadRequest();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await newsService.DeleteAsync(id))
                return Ok("Delete Successfully");

            return NotFound();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetNewsByIdAsync([FromRoute] int id)
        {
            var res = await _mediator.Send(new GetNewsByIdQuery(id));

            if (res is null)
                return NotFound("News not found !");

            return Ok(res);
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(int id, NewsVM_Input input)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            if (await newsService.UpdateAsync(id, input))
                return Ok("Edit Successfully");

            return BadRequest();
        }
    }
}
