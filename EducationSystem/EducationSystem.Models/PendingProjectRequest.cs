using EducationSystem.Models.Accounts;

namespace EducationSystem.Models
{
    public class PendingProjectRequest
    {
        public int ProjectId { get; set; }

        public int AccountId { get; set; }

        public Project Project { get; set; }

        public DeveloperAccount Account { get; set; }
    }
}