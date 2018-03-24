namespace EducationSystem.Models.Accounts
{
    public class AccountRequest
    {
        public int ProjectId { get; set; }

        public int AccountId { get; set; }

        public Project Project { get; set; }

        public DeveloperAccount Account { get; set; }
    }
}