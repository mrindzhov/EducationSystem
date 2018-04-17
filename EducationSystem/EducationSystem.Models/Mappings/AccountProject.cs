namespace EducationSystem.Models.Mappings
{
    public abstract class AccountProject
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public string AccountId { get; set; }

        public Project Project { get; set; }

        public User Account { get; set; }
    }
}