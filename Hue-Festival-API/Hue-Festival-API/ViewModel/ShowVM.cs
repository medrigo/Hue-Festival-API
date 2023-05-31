using System.ComponentModel.DataAnnotations;

namespace HueFestival_OnlineTicket.ViewModel
{
    public class ShowVM
    {
        public int Id { get; set; }
        public int ProgramId { get; set; }
        public string ProgramName { get; set; }
        public int Type_Inoff { get; set; }
        public string Time { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LocationId { get; set; }
        public string LocationTitle { get; set; }
    }

    public class ShowVM_Input
    {
        public int ProgramId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LocationId { get; set; }
        public int ShowCategoryId { get; set; }
    }

    public class ShowVM_Details
    {
        public string ProgramName { get; set; }
        public string Time { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string LocationTitle { get; set; }
        public double Price { get; set; }
        public string ShowCategoryName { get; set; }
        public string ShowCategoryContent { get; set; }
    }

    public class ShowVM_SalesTicket
    {
        public int ShowId { get; set; }
        public string ProgramName { get; set; }
        public DateTime StartDate { get; set; }
    }
}
