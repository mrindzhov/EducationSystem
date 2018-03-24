using System.Collections.Generic;

namespace EducationSystem.Models.Accounts
{
    public class DeveloperAccount
    {
        public DeveloperAccount()
        {
            this.Skills = new HashSet<Skill>();
            this.AcceptedProjects = new HashSet<Project>();
            this.RequestedProjects = new HashSet<Project>();
        }

        public int Id { get; set; }

        public string FullName { get; set; }

        public ICollection<Skill> Skills { get; set; }

        public ICollection<Project> RequestedProjects { get; set; }

        public ICollection<Project> AcceptedProjects { get; set; }
    }
}