using AutoMapper;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.ViewModel;

namespace HueFestival_OnlineTicket.Helper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<LocationCategory, LocationCategoryVM_Input>().ReverseMap();
            CreateMap<LocationCategory, LocationCategoryVM>().ReverseMap();
            CreateMap<LocationCategory, LocationCategoryVM_Details>().ReverseMap();

            CreateMap<Location, LocationVM>().ReverseMap();
            CreateMap<Location, LocationVM_Input>().ReverseMap();
            CreateMap<Location, LocationVM_Details>()
                .ForMember(des => des.LocationCategory, act => act.MapFrom(src => src.LocationCategory.Title));

            CreateMap<TicketLocation, TicketLocationVM>().ReverseMap();
            CreateMap<TicketLocation, TicketLocationVM_Input>().ReverseMap();

            CreateMap<News, NewsVM_Input>().ReverseMap();
            CreateMap<News, NewsVM>().ReverseMap();
            CreateMap<News, NewsVM_Details>().ReverseMap();

            CreateMap<HelpMenu, HelpMenuVM>().ReverseMap();
            CreateMap<HelpMenu, HelpMenuVM_Input>().ReverseMap();
            CreateMap<HelpMenu, HelpMenuVM_Details>().ReverseMap();

            CreateMap<Programme, ProgrammeVM>().ReverseMap();
            CreateMap<Programme, ProgrammeVM_Details>().ReverseMap();
            CreateMap<Programme, ProgrammeVM_Input>().ReverseMap();

            CreateMap<ProgrammeImage, ProgrammeImageVM>().ReverseMap();

            CreateMap<Show, ShowVM_Input>().ReverseMap();
            CreateMap<Show, ShowVM>()
                .ForMember(des => des.ProgramName, act => act.MapFrom(src => src.Programme.Name))
                .ForMember(des => des.LocationTitle, act => act.MapFrom(src => src.Location.Title))
                .ForMember(des => des.Time, act => act.MapFrom(src => src.StartDate.ToString("HH:mm:ss")))
                .ForMember(des => des.Type_Inoff, act => act.MapFrom(src => src.Programme.Type_Inoff));
            CreateMap<Show, ShowVM_Details>()
                .ForMember(des => des.ProgramName, act => act.MapFrom(src => src.Programme.Name))
                .ForMember(des => des.LocationTitle, act => act.MapFrom(src => src.Location.Title))
                .ForMember(des => des.Time, act => act.MapFrom(src => src.StartDate.ToString("HH:mm:ss")))
                .ForMember(des => des.Price, act => act.MapFrom(src => src.Programme.Price))
                .ForMember(des => des.ShowCategoryName, act => act.MapFrom(src => src.ShowCategory.Name))
                .ForMember(des => des.ShowCategoryContent, act => act.MapFrom(src => src.ShowCategory.Content));
            CreateMap<Show, ShowVM_SalesTicket>()
                .ForMember(des => des.ShowId, act => act.MapFrom(src => src.Id))
                .ForMember(des => des.ProgramName, act => act.MapFrom(src => src.Programme.Name));

            CreateMap<ShowCategory, ShowCategoryVM_Input>().ReverseMap();
            CreateMap<ShowCategory, ShowCategoryVM>().ReverseMap();

            CreateMap<User, UserVM_Input>().ReverseMap();
            CreateMap<User, UserVM>().ReverseMap();

            CreateMap<Employee, EmployeeVM_Create>().ReverseMap();
            CreateMap<Employee, EmployeeVM>().ReverseMap();
            CreateMap<Employee, EmployeeVM_Update>().ReverseMap();

            CreateMap<TicketType, TicketTypeVM_Input>().ReverseMap();
            CreateMap<TicketType, TicketTypeVM>().ReverseMap();

            CreateMap<Ticket, TicketVM>()
                .ForMember(des => des.ShowName, act => act.MapFrom(src => src.TicketType.Show.Programme.Name))
                .ForMember(des => des.ShowId, act => act.MapFrom(src => src.TicketType.ShowId))
                .ForMember(des => des.Day, act => act.MapFrom(src => src.TicketType.Show.StartDate.ToShortDateString()))
                .ForMember(des => des.Time, act => act.MapFrom(src => src.TicketType.Show.StartDate.ToShortTimeString()))
                .ForMember(des => des.Type, act => act.MapFrom(src => src.TicketType.Type))
                .ForMember(des => des.Price, act => act.MapFrom(src => src.TicketType.Price));

            CreateMap<LocationFavorite, LocationFavoriteVM>()
                .ForMember(des => des.LocationTitle, act => act.MapFrom(src => src.Location.Title))
                .ForMember(des => des.LocationImage, act => act.MapFrom(src => src.Location.Image));

            CreateMap<ShowFavorite, ShowFavoriteVM>()
                .ForMember(des => des.ProgrammeName, act => act.MapFrom(src => src.Show.Programme.Name))
                .ForMember(des => des.ListProgrammeImage, act => act.MapFrom(src => src.Show.Programme.ListProgrammeImage));

            CreateMap<CheckIn, CheckInVM>()
                .ForMember(des => des.TicketCode, act => act.MapFrom(src => src.Ticket.Code))
                .ForMember(des => des.DateCheckIn, act => act.MapFrom(src => src.DateCreated.ToString("dd-MM-yyyy")))
                .ForMember(des => des.TypeTicket, act => act.MapFrom(src => src.Ticket.TicketType.Type))
                .ForMember(des => des.EmployeeCheckIn, act => act.MapFrom(src => src.Employee.Name))
                .ForMember(des => des.Status, act => act.MapFrom(src => src.Status))
                .ForMember(des => des.PriceTicket, act => act.MapFrom(src => src.Ticket.TicketType.Price));
        }
    }
}
