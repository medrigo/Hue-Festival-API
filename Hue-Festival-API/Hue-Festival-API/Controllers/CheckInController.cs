using AutoMapper;
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
    public class CheckInController : ControllerBase
    {
        private readonly ICheckInService checkInService;
        private readonly IMapper mapper;

        public CheckInController(ICheckInService _checkInService, IMapper _mapper)
        {
            checkInService = _checkInService;
            mapper = _mapper;
        }

        [Authorize]
        [HttpPost("check_in")]
        public async Task<IActionResult> CheckIn(string code)
        {
            string employeeId = User.FindFirstValue("id");

            var resultCheckIn = await checkInService.CheckInAsync(code, employeeId);

            return Ok(resultCheckIn);
        }

        [Authorize]
        [HttpGet("report")]
        public async Task<IActionResult> Report()
        {
            string employeeId = User.FindFirstValue("id");

            return Ok(await checkInService.ReportAsync(Guid.Parse(employeeId)));
        }

        [Authorize]
        [HttpGet("get_history_check_in")]
        public async Task<IActionResult> GetCheckinHistory(DateTime? date, int? programmeId, string? typeTicket)
        {
            string employeeId = User.FindFirstValue("id");

            return Ok(mapper.Map<List<CheckInVM>>(await checkInService.GetHistoryCheckIn(Guid.Parse(employeeId), date, typeTicket, programmeId)));
        }
    }
}
