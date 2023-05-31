namespace HueFestival_OnlineTicket.ViewModel
{
    public class CheckInVM
    {
        public string TicketCode { get; set; }
        public string DateCheckIn { get; set; }
        public string TypeTicket { get; set; }
        public string EmployeeCheckIn { get; set; }
        public double PriceTicket { get; set; }
        public bool Status { get; set; }
    }

    public class CheckInVM_Report
    {
        public string ShowName { get; set; }
        public int CountTicket { get; set; }
    }


}
