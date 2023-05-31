using HueFestival_OnlineTicket.Core.InterfaceService;
using HueFestival_OnlineTicket.Queries.User;
using HueFestival_OnlineTicket.Queries.User.GetAllUser;
using HueFestival_OnlineTicket.Queries.User.GetWishList;
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
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMediator _mediator;

        public UserController(IUserService _userService, IMediator mediator)
        {
            userService = _userService;
            _mediator = mediator;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(UserVM_Input input)
        {
            if (await userService.GetByPhone(input.PhoneNumber) != null)
                return BadRequest("Số điện thoại đã tồn tại");

            if (await userService.AddAsync(input))
                return Ok("Successfully");

            return Problem();
        }

        [HttpDelete("delete_user")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await userService.DeleteAsync(id))
                return Ok("Successfully");

            return Problem("User not found or error, please try again");
        }

        [Authorize]
        [HttpPut("change_password")]
        public async Task<IActionResult> ChangePassword(UserVM_ChangePassword input)
        {
            if (input.NewPassword != input.ConfirmNewPassword)
                return BadRequest("Other new password confirm new password");

            string userId = User.FindFirstValue("id");

            if (!await userService.ChangePassword(Int32.Parse(userId), input))
                return BadRequest("Wrong password");

            return Ok("Successfully");
        }

        //[Authorize]
        [HttpGet("get-wishlist")]
        public async Task<IActionResult> GetWishListAsync([FromRoute] int id)
        {
            var res = await _mediator.Send(new GetWishListQuery(id));
            if (res == null)
                return NotFound();
            return Ok(res);
        }

        [HttpPut("update_role")]
        public async Task<IActionResult> UpdateRole(UserVM_UpdateRole input)
        {
            if (await userService.UpdateRoleAsync(input))
                return Ok("Successfully");

            return BadRequest();
        }

        [HttpGet("get-all-user")]
        public async Task<IActionResult> GetAllAsync()
        {
            var res = await _mediator.Send(new GetAllUserQuery());
            if (res == null)
                return NotFound();
            return Ok(res); 
        }
            

        [HttpPut("update_infomation")]
        public async Task<IActionResult> UpdateInfo(UserVM_UpdateInfo input)
        {
            if (await userService.UpdateInfoAsync(input)) return Ok("Successfully");

            return BadRequest();
        }
    }
}
