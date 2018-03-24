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
            this.Contributors = new HashSet<AccountProject>();
            this.Pending = new HashSet<AccountRequestProject>();
            this.Requested = new HashSet<ProjectRequestAccount>();
        }

        public int ProjectId { get; set; }

        public string Name { get; set; }

        public DateTime DateStarted { get; set; }

        public DateTime? EndDate { get; set; }

        public string Description { get; set; }

        public string Needs { get; set; }

        public bool IsOpenForContributors { get; set; }

        public int ProductOwnerId { get; set; }
        public Account ProductOwner { get; set; }
        
        public ICollection<ProjectFeedbackRank> Feedbacks { get; set; }

        public ICollection<Resource> Resources { get; set; }

        public ICollection<TechnologyType> Technologies { get; set; }

        public ICollection<AccountProject> Contributors { get; set; }

        public ICollection<AccountRequestProject> Pending { get; set; }

        public ICollection<ProjectRequestAccount> Requested { get; set; }
    }
}
