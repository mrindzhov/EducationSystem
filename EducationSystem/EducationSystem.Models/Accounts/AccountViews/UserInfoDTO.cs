namespace EducationSystem.Models.Accounts.AccountViews
{
    public class UserInfoDTO
    {
        public string Email { get; set; }

        public bool HasRegistered { get; set; }

        public string LoginProvider { get; set; }
    }
}