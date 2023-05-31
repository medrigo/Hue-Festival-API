namespace HueFestival_OnlineTicket.Model
{
    public class Programme
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public int Type_Inoff { get; set; }
        public int Type_Program { get; set; }
        public double Price { get; set; }

        public List<ProgrammeImage> ListProgrammeImage { get; set; }
        public List<Show> ListShow { get; set; }
    }
}
