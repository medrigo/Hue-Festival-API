namespace HueFestival_OnlineTicket.ViewModel
{
    public class ProgrammeVM_Input
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public int Type_Inoff { get; set; }
        public int Type_Program { get; set; }
        public double Price { get; set; }
        public List<ProgrammeImageVM> ListProgrammeImage { get; set; }
    }

    public class ProgrammeVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProgrammeImageVM> ListProgrammeImage { get; set; }
    }

    public class ProgrammeVM_Details
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public int Type_Inoff { get; set; }
        public int Type_Program { get; set; }
        public double Price { get; set; }
        public List<ProgrammeImageVM> ListProgrammeImage { get; set; }
        public List<ShowVM> ListShow { get; set; }
    }
}
