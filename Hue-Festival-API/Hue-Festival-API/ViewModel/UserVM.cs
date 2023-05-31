namespace HueFestival_OnlineTicket.ViewModel
{
    public class UserVM_Input
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? Role { get; set; }
    }

    public class UserVM_Login
    {
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }

    public class UserVM_UpdateRole
    {
        public int UserId { get; set; }
        public string Role { get; set; }
    }

    public class UserVM_ChangePassword
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }

    public class UserVM_ShowAndLocationFavorite
    {
        public List<ShowFavoriteVM> ListShowFavorite { get; set; }
        public List<LocationFavoriteVM> ListLocationFavorite { get; set; }
    }

    public class UserVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
    }

    public class UserVM_UpdateInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
