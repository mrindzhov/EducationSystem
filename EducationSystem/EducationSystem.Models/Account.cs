using System.Collections.Generic;
using EducationSystem.Models.Enums;

namespace EducationSystem.Models
{
    public class Account
    {
        public Account()
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
