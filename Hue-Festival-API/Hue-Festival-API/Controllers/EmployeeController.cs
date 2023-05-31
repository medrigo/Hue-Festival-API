using AutoMapper;
using HueFestival_OnlineTicket.Core.InterfaceService;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.Queries.Employee.GetAllEmployee;
using HueFestival_OnlineTicket.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HueFestival_OnlineTicket.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IEmployeeService employeeService;
        private readonly IMediator _mediator;

        public EmployeeController(IMapper _mapper, IEmployeeService _employeeService, IMediator mediator)
        {
            mapper = _mapper;
            employeeService = _employeeService;
            _mediator = mediator;
        }

        [HttpPost("")]
        public async Task<IActionResult> Add(EmployeeVM_Create input)
        {
            try
            {
                var employee = mapper.Map<Employee>(input);

                employee.Id = Guid.NewGuid();
                employee.Activate = false;

                await employeeService.AddAsync(employee);

                return Ok("Add thành công");
            }
            catch(Exception ex)
            {
                return Problem(detail: ex.Message);
            }
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var employees = await _mediator.Send(new GetAllEmployeeQuery());
            if(employees == null)
            {
                return NoContent();
            }
            return Ok(employees);
        }
            

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var employee = await employeeService.GetByIdAsync(id);

            if (employee == null)
                return NotFound();

            await employeeService.DeleteAsync(employee);

            return Ok("Delete thành công");
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Update(Guid id, EmployeeVM_Update input)
        {
            try
            {
                var employee = await employeeService.GetByIdAsync(id);

                if (employee == null)
                    return NotFound();

                mapper.Map<EmployeeVM_Update, Employee>(input, employee);

                await employeeService.UpdateAsync(employee);

                return Ok("Update thành công");
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message);
            }
        }

        [Authorize]
        [HttpPut("change-password")]
        public async Task<IActionResult> ChangePassword(EmployeeVM_ChangePassword password)
        {
            if (password.NewPassword != password.ConfirmNewPasswrod)
                return BadRequest("Other new password confirm new password");

            string userId = User.FindFirstValue("id");

            if(!await employeeService.ChangePasswordAsync(Guid.Parse(userId), password))
                return BadRequest("Wrong password");

            return Ok("Successfully");
        }
    }
}
