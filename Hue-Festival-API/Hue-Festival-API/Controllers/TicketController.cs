using AutoMapper;
using HueFestival_OnlineTicket.Core.InterfaceService;
using HueFestival_OnlineTicket.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Security.Claims;

namespace HueFestival_OnlineTicket.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService ticketService;
        private readonly IMapper mapper;

        public TicketController(ITicketService _ticketService, IMapper _mapper)
        {
            ticketService = _ticketService;
            mapper = _mapper;
        }

        [Authorize(Roles = "customer")]
        [HttpPost("buy_ticket")]
        public async Task<IActionResult> BuyTicket(TicketVM_Buy ticket)
        {
            string userId = User.FindFirstValue("id");

            var result = await ticketService.BuyTicketAsync(ticket, Int32.Parse(userId));

            switch(result)
            {
                case 1:
                    return BadRequest("Vé không tồn tại");
                case 2:
                    return BadRequest("Số lượng vé không đủ");
                case 3:
                    return Ok("Mua thành công");
                case 4:
                    return Problem(detail: "Đã sảy ra lỗi, vui lòng thử lại");
                default: 
                    return NoContent();
            }
        }

        [HttpGet("get_all_ticket")]
        public async Task<IActionResult> GetAll()
            => Ok(mapper.Map<List<TicketVM>>(await ticketService.GetAllAsync()));

        [Authorize(Roles = "customer")]
        [HttpGet("get_list_purchased_tickets")]
        public async Task<IActionResult> GetByUserId()
        {
            string userId = User.FindFirstValue("id");

            return Ok(mapper.Map<List<TicketVM>>(await ticketService.GetByUserId(Int32.Parse(userId))));
        }

        [HttpGet("get_qrcode_ticket")]
        public async Task<IActionResult> GetQRCodeTicket(Guid ticketId)
        {
            var ticket = await ticketService.GetByIdAsync(ticketId);

            if (ticket is null)
                return NotFound();

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(ticket.Code, QRCodeGenerator.ECCLevel.Q);
            BitmapByteQRCode qrCode = new BitmapByteQRCode(qrCodeData);
            byte[] qrCodeAsBitmapByteArr = qrCode.GetGraphic(10);

            return File(qrCodeAsBitmapByteArr, "image/jpeg");
        }
    }
}
