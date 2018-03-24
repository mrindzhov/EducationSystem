using System;
using EducationSystem.Models.Enums;
using System.Collections.Generic;

namespace EducationSystem.Models
{
    public class Project
    {
        public Project()
        {
            this.Feedbacks = new HashSet<ProjectFeedbackRank>();
            this.Resources = new HashSet<Resource>();
            this.Contributors = new HashSet<Account>();
            this.Pending = new HashSet<PendingProjectRequest>();
            this.AccountRequests = new HashSet<AccountRequest>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Description { get; set; }

        public string Needs { get; set; }

        public bool IsTeamFormed { get; set; }

        public int ProductOwnerId { get; set; }

        public Account ProductOwner { get; set; }
        
        public ICollection<ProjectFeedbackRank> Feedbacks { get; set; }

        public ICollection<Resource> Resources { get; set; }

        public ICollection<DeveloperType> DeveloperTypesNeeded { get; set; }

        public ICollection<Account> Contributors { get; set; }

        public ICollection<PendingProjectRequest> Pending { get; set; }

        public ICollection<AccountRequest> AccountRequests { get; set; }
    }
}
