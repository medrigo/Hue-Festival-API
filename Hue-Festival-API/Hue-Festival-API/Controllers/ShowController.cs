using HueFestival_OnlineTicket.Core.InterfaceService;
using HueFestival_OnlineTicket.Core.Service;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HueFestival_OnlineTicket.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ShowController : ControllerBase
    {
        private readonly IShowService showService;

        public ShowController(IShowService _showService)
        {
            showService = _showService;
        }

        [HttpGet("get_show_sales_ticket")]
        public async Task<IActionResult> GetShowSalesTicket()
            => Ok(await showService.GetListShowSalesTicketAsync());

        [Authorize]
        [HttpPost("add_favorite")]
        public async Task<IActionResult> AddFavorite(int showId)
        {
            string userId = User.FindFirstValue("id");

            if (await showService.AddFavoriteAsync(Int32.Parse(userId), showId))
                return Ok("Successfully");

            return BadRequest();
        }

        [HttpDelete("delete_favorite")]
        public async Task<IActionResult> DeleteFavorite(Guid id)
        {
            if (await showService.DeleteFavoriteAsync(id))
                return Ok("Delete Successfully");

            return Problem(title: "Wrong ID or error, please try again");
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(ShowVM_Input input)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var result = await showService.AddAsync(input);

            switch(result)
            {
                case 1:
                    return NotFound(new { Success = false ,Message = "Location, program or location category not found" });
                case 2:
                    return Problem();
                case 3:
                    return Ok("Successfully");
                default:
                    return NoContent();
            }
        }

        [HttpGet("get_calendar_list")]
        public async Task<IActionResult> GetCalendarList()
            => Ok(await showService.GetCalendarList());

        [HttpGet("get_by_date")]
        public async Task<IActionResult> GetByDate(DateTime date)
            => Ok(await showService.GetByDate(date));

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id) 
        {
            var result = await showService.DeleteAsync(id);

            switch (result)
            {
                case 1:
                    return NotFound();
                case 2:
                    return Problem();
                case 3:
                    return Ok("Successfully");
                default:
                    return NoContent();
            }
        }

        [HttpPut("edit")]
        public async Task<IActionResult> Edit(int id, ShowVM_Input input)
        {
            var result = await showService.UpdateAsync(id, input);

            switch (result)
            {
                case 1:
                    return NotFound();
                case 2:
                    return Problem();
                case 3:
                    return Ok("Successfully");
                default:
                    return NoContent();
            }
        }

        [HttpGet("get_details")]
        public async Task<IActionResult> GetDetails(int id)
        {
            var show = await showService.GetDetailsAsync(id);

            if(show != null) 
                return Ok(show);

            return NotFound();
        }

        [HttpGet("get_show_list")]
        public async Task<IActionResult> GetAll()
            => Ok(await showService.GetAllAsync());
    }
}
