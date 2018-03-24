using EducationSystem.Models.Mappings;
using System.Collections.Generic;

namespace EducationSystem.Models.Accounts
{
    public class DeveloperAccount
    {
        public DeveloperAccount()
        {
            this.Skills = new HashSet<Skill>();
            this.AcceptedProjects = new HashSet<AcceptedProjectRequest>();
            this.RequestedProjects = new HashSet<RequestedProjectRequest>();
            this.ReceivedProjectRequests = new HashSet<ReceivedProjectRequest>();
        }

        public int Id { get; set; }

        public string FullName { get; set; }

        public int ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public ICollection<Skill> Skills { get; set; }

        public ICollection<RequestedProjectRequest> RequestedProjects { get; set; }

        public ICollection<AcceptedProjectRequest> AcceptedProjects { get; set; }

        public ICollection<ReceivedProjectRequest> ReceivedProjectRequests { get; set; }
    }
}