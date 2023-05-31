using HueFestival_OnlineTicket.Core.InterfaceService;
using HueFestival_OnlineTicket.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HueFestival_OnlineTicket.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ShowCatrgoryController : ControllerBase
    {
        private readonly IShowCategoryService showCtgSvc;

        public ShowCatrgoryController(IShowCategoryService _showCtgSvc)
        {
            showCtgSvc = _showCtgSvc;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(ShowCategoryVM_Input input)
        {
            var result = await showCtgSvc.AddAsync(input);

            switch(result)
            {
                case 1:
                    return Problem();
                case 2:
                    return Ok("Successfully");
                default:
                    return NoContent();
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll() 
            => Ok(await showCtgSvc.GetAllAsync());

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await showCtgSvc.DeleteAsync(id);

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

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(int id, ShowCategoryVM_Input input)
        {
            var result = await showCtgSvc.UpdateAsync(id, input);

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
    }
}
