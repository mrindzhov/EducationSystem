using System.Collections.Generic;

namespace EducationSystem.Models.Accounts
{
    public class CompanyAccount
    {
        public CompanyAccount()
        {
            this.PublishedProjects = new HashSet<Project>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public ICollection<Project> PublishedProjects { get; set; }
    }
}