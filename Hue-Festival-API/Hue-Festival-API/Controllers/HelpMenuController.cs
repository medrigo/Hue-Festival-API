using HueFestival_OnlineTicket.Core.InterfaceService;
using HueFestival_OnlineTicket.Queries.HelpMenu.GetAllHelpMenu;
using HueFestival_OnlineTicket.Queries.HelpMenu.GetHelpMenuById;
using HueFestival_OnlineTicket.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

namespace HueFestival_OnlineTicket.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class HelpMenuController : ControllerBase
    {
        private readonly IHelpMenuService helpMenuService;
        private readonly IMediator _mediator;

        public HelpMenuController(IHelpMenuService _helpMenuService, IMediator mediator)
        {
            helpMenuService = _helpMenuService;
            _mediator = mediator;
        }

        [HttpPost("")]
        public async Task<IActionResult> Add(HelpMenuVM_Input input)
        {
            if(!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await helpMenuService.AddAsync(input);

            return Ok("Successfully");
        }

        [HttpDelete("")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await helpMenuService.DeleteAsync(id))
                return Ok("Delete Successfully");

            return BadRequest();
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var res = await _mediator.Send(new GetAllHelpMenuQuery());
            if (res == null)
                return NotFound();
            return Ok(res);
        }
           

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetHelpMenuByIdAsync([FromRoute] int id) 
        {
            var res = await _mediator.Send(new GetHelpMenuByIdQuery(id));

            if(res == null)
                return NotFound();

            return Ok(res);
        }

        [HttpPut("")]
        public async Task<IActionResult> Edit(int id, HelpMenuVM_Input input)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            if (await helpMenuService.UpdateAsync(id, input))
                return Ok("Update Successfully");

            return BadRequest();
        }
    }
}
