namespace EducationSystem.Models.Account.Dtos
{
    public class UserInfoDTO
    {
        public string Email { get; set; }

        public bool HasRegistered { get; set; }

        public string LoginProvider { get; set; }
    }
}