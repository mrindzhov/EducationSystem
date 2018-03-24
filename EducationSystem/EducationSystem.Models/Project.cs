using System;
using EducationSystem.Models.Enums;
using System.Collections.Generic;
using EducationSystem.Models.Accounts;

namespace EducationSystem.Models
{
    public class Project
    {
        public Project()
        {
            this.Feedbacks = new HashSet<FeedbackRank>();
            this.Resources = new HashSet<Resource>();
            this.Contributors = new HashSet<DeveloperAccount>();
            this.Pending = new HashSet<PendingProjectRequest>();
            this.AccountRequests = new HashSet<AccountRequest>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Description { get; set; }

        public string Requirements { get; set; }

        public bool IsTeamFormed { get; set; }

        public int ProductOwnerId { get; set; }

        public DeveloperAccount ProductOwner { get; set; } // ApplcationUser

        public ICollection<FeedbackRank> Feedbacks { get; set; }

        public ICollection<Resource> Resources { get; set; }

        public ICollection<SkillType> DeveloperTypesNeeded { get; set; }

        public ICollection<DeveloperAccount> Contributors { get; set; }

        public ICollection<PendingProjectRequest> Pending { get; set; }

        public ICollection<AccountRequest> AccountRequests { get; set; }
    }
}