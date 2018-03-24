
namespace EducationSystem.Models.Mappings
{
    public abstract class AccountProject
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public int AccountId { get; set; }

        public Project Project { get; set; }

        public ApplicationUser Account { get; set; }
    }
}
