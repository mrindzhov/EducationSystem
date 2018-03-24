using EducationSystem.Models.Enums;
using System.Collections.Generic;

namespace EducationSystem.Models
{
    public class Account
    {
        public Account()
        {
            this.Strengths = new HashSet<TechnologyType>();
            this.ProjectContributing = new HashSet<AccountProject>();
            this.Requests = new HashSet<AccountRequestProject>();
            this.Pending = new HashSet<ProjectRequestAccount>();
        }

        public int AccountId { get; set; }
        
        public string Name { get; set; }
        
        public AccountType AccountType { get; set; }

        public ICollection<TechnologyType> Strengths { get; set; }

        public ICollection<AccountProject> ProjectContributing { get; set; }

        public ICollection<AccountRequestProject> Requests { get; set; }

        public ICollection<ProjectRequestAccount> Pending { get; set; }
    }
}
