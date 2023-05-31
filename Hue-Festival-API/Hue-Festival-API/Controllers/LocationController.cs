using HueFestival_OnlineTicket.Core.InterfaceService;
using HueFestival_OnlineTicket.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HueFestival_OnlineTicket.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService locationService;

        public LocationController(ILocationService _locationService)
        {
            locationService = _locationService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(LocationVM_Input locationVM_Input)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            if (await locationService.AddAsync(locationVM_Input))
                return Ok("Add Successfully");
            
            return BadRequest();
        }

        [Authorize]
        [HttpPost("add_favorite")]
        public async Task<IActionResult> AddFavorite(int locationId)
        {
            string userId = User.FindFirstValue("id");

            if (await locationService.AddFavoriteAsync(Int32.Parse(userId), locationId)) 
                return Ok("Successfully");

            return BadRequest();
        }

        [HttpDelete("delete_favorite")]
        public async Task<IActionResult> DeleteFavorite(Guid id)
        {
            if(await locationService.DeleteFavoriteAsync(id))
                return Ok("Delete Successfully");

            return Problem(title: "Wrong ID or error, please try again");
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await locationService.GetByIdAsync(id);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await locationService.DeleteAsync(id);

            if (!result)
                return NotFound();

            return Ok("Delete Successfully");
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(int id, LocationVM_Input input)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            if(await locationService.UpdateAsync(id, input))
                return Ok("Edit Successfully");

            return BadRequest();
        }
    }
}
