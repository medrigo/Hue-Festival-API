using AutoMapper;
using HueFestival_OnlineTicket.Core.InterfaceService;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HueFestival_OnlineTicket.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TicketTypeController : ControllerBase
    {
        private readonly ITicketTypeService ticketTypeService;
        private readonly IMapper mapper;

        public TicketTypeController(ITicketTypeService _ticketTypeService, IMapper _mapper)
        {
            ticketTypeService = _ticketTypeService;
            mapper = _mapper;
        }

        [HttpPost("add_ticket_type")]
        public async Task<IActionResult> Add(TicketTypeVM_Input input)
        {
            var mapInput = mapper.Map<TicketType>(input);

            mapInput.Id = Guid.NewGuid();

            await ticketTypeService.AddAsync(mapInput);

            return Ok("Add thành công");
        }

        [HttpGet("get_by_show")]
        public async Task<IActionResult> GetByShowId(int id)
            => Ok(mapper.Map<List<TicketTypeVM>>(await ticketTypeService.GetByShowIdAsync(id)));

        [HttpGet("get_all")]
        public async Task<IActionResult> GetAll()
            => Ok(mapper.Map<List<TicketTypeVM>>(await ticketTypeService.GetAllAsync()));

        [HttpPut("update")]
        public async Task<IActionResult> Update(Guid id, TicketTypeVM_Input input)
        {
            var ticketType = await ticketTypeService.GetByIdAsync(id);

            if (ticketType == null)
                return NotFound();

            await ticketTypeService.UpdateAsync(mapper.Map(input, ticketType));

            return Ok("Update thành công");
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var ticketType = await ticketTypeService.GetByIdAsync(id);

            if (ticketType == null)
                return NotFound();

            await ticketTypeService.DeleteAsync(ticketType);

            return Ok("Delete thành công");
        }
    }
}
