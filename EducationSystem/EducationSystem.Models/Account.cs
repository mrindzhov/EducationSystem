using EducationSystem.Models.Enums;
using System.Collections.Generic;

namespace EducationSystem.Models
{
    public class Account
    {
        public Account()
        {
            this.Strengths = new HashSet<DeveloperType>();
            this.Projects = new HashSet<Project>();
            this.Requests = new HashSet<PendingProjectRequest>();
            this.Pending = new HashSet<AccountRequest>();
        }

        public int AccountId { get; set; }
        
        public string Name { get; set; }
        
        public AccountType AccountType { get; set; }

        public ICollection<DeveloperType> Strengths { get; set; }

        public ICollection<Project> Projects { get; set; }

        public ICollection<PendingProjectRequest> Requests { get; set; }

        public ICollection<AccountRequest> Pending { get; set; }
    }
}
