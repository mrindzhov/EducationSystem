namespace EducationSystem.Models
{
    public class AccountRequestProject
    {
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}