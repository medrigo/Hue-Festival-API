using HueFestival_OnlineTicket.Core.InterfaceService;
using HueFestival_OnlineTicket.Core.UnitOfWork;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.ViewModel;
using QRCoder;

namespace HueFestival_OnlineTicket.Core.Service
{
    public class TicketService : ITicketService
    {
        private readonly IUnitOfWork unitOfWork;

        public TicketService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public async Task<int> BuyTicketAsync(TicketVM_Buy ticket, int userId)
        {
            try
            {
                var ticketType = await unitOfWork.TicketTypeRepo.GetByIdAsync(ticket.TicketTypeId);

                if (ticketType == null)
                    return 1;

                if (ticketType.Quantity < ticket.Quantity)
                    return 2;

                ticketType.Quantity -= ticket.Quantity;

                unitOfWork.TicketTypeRepo.Update(ticketType);
                await unitOfWork.CommitAsync();

                var createdDate = DateTime.Now;

                for (int i = 0; i < ticket.Quantity; i++)
                {
                    await unitOfWork.TicketRepo.AddAsync(new Ticket
                    {
                        Id = Guid.NewGuid(),
                        TicketTypeId = ticket.TicketTypeId,
                        UserId = userId,
                        CreatedDate = createdDate,
                        Status = false,
                        Code = GenerateCode()
                    });
                }
                await unitOfWork.CommitAsync();

                return 3;
            }
            catch
            {
                return 4;

            }
        }

        private byte[] GenerateQRCode(string code)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
            BitmapByteQRCode qrCode = new BitmapByteQRCode(qrCodeData);
            byte[] qrCodeAsBitmapByteArr = qrCode.GetGraphic(10);

            return qrCodeAsBitmapByteArr;
        }

        private string GenerateCode()
        {
            Random rand = new Random();
            string chars = "QWERTYUIOPASDFGHJKLZXCVBNM0123456789";
            int stringlen = rand.Next(20, 30);
            string code = "";

            for (int i = 0; i < stringlen; i++)
            {
                int x = rand.Next(chars.Length);

                code += chars[x];
            }

            if(unitOfWork.TicketRepo.CheckCodeAsync(code))
            {
                GenerateCode();
            }

            return code;
        }

        public async Task<List<Ticket>> GetAllAsync()
            => await unitOfWork.TicketRepo.GetAllAsync();

        public async Task<List<Ticket>> GetByUserId(int userId)
            => await unitOfWork.TicketRepo.GetByUserIdAsync(userId);

        public async Task<Ticket> GetByIdAsync(Guid ticketId)
            => await unitOfWork.TicketRepo.GetById(ticketId);
    }
}
