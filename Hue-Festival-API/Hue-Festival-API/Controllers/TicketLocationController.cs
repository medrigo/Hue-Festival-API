using HueFestival_OnlineTicket.Core.InterfaceService;
using HueFestival_OnlineTicket.Servies.Interface;
using HueFestival_OnlineTicket.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace HueFestival_OnlineTicket.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TicketLocationController : ControllerBase
    {
        private readonly ITicketLocationService ticketLocationService;

        public TicketLocationController(ITicketLocationService _ticketLocationService)
        {
            ticketLocationService = _ticketLocationService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
            => Ok(await ticketLocationService.GetAllAsync());

        [HttpPost("Add")]
        public async Task<IActionResult> Add(TicketLocationVM_Input ticketLocationVM_Input)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await ticketLocationService.AddASync(ticketLocationVM_Input);

            return Ok("Successfully");
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await ticketLocationService.DeleteAsync(id))
                return Ok("Delete Successfully");

            return NotFound();
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(int id, TicketLocationVM_Input input)
        {
            if(await ticketLocationService.UpdateAsync(id, input))
                return Ok("Update Successfully");
        
            return BadRequest();
        }
    }
}
