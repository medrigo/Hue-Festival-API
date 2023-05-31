using AutoMapper;
using HueFestival_OnlineTicket.Core.InterfaceService;
using HueFestival_OnlineTicket.Data;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.Queries.LocationCategory;
using HueFestival_OnlineTicket.Queries.LocationCategory.GetAllLocationCategory;
using HueFestival_OnlineTicket.Queries.LocationCategory.GetLocationCategoryById;
using HueFestival_OnlineTicket.Servies.Interface;
using HueFestival_OnlineTicket.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HueFestival_OnlineTicket.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LocationCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILocationCategoryService locationCategoryService;

        public LocationCategoryController(ILocationCategoryService _locationCategoryService, IMediator mediator)
        {
            locationCategoryService = _locationCategoryService;
            _mediator = mediator;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(LocationCategoryVM_Input locationCategoryVM_Input)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await locationCategoryService.AddAsync(locationCategoryVM_Input);

            return Ok("Successfully");
        }

        [HttpPost("update")]
        public async Task<IActionResult> Edit(int id, LocationCategoryVM_Input input)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            if(await locationCategoryService.UpdateAsync(id, input))
                return Ok("Update Successfully");

            return BadRequest();
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(await locationCategoryService.DeleteAsync(id))
                return Ok("Delete Successfully");

            return NotFound();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var res = await _mediator.Send(new GetLocationCategoryByIdQuery(id));

            if (res is null)
                return NotFound();

            return Ok(res);
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var res = await _mediator.Send(new GetAllLocationCategoryQuery());
            if(res is null)
                return NoContent();
            return Ok(res);
        }
           
    }
}
