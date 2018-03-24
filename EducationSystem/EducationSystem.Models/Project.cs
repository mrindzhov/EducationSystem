using EducationSystem.Models.Mappings;
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
            this.Feedbacks = new HashSet<Feedback>();
            this.Resources = new HashSet<Resource>();
            this.AcceptedDevelopers = new HashSet<AcceptedProjectRequest>();
            this.RequestedDevelopers = new HashSet<RequestedProjectRequest>();
            this.ReceivedRequests = new HashSet<ReceivedProjectRequest>();
            this.SkillsNeeded = new HashSet<Skill>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreateDate { get; set; }

        public string GitHubUrl { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Description { get; set; }

        public string Requirements { get; set; }

        public bool IsTeamFormed { get; set; }

        public int ProductOwnerId { get; set; }

        public ApplicationUser ProductOwner { get; set; }

        public ICollection<Feedback> Feedbacks { get; set; }

        public ICollection<Resource> Resources { get; set; }

        public ICollection<Skill> SkillsNeeded { get; set; }

        public ICollection<AcceptedProjectRequest> AcceptedDevelopers { get; set; }

        public ICollection<RequestedProjectRequest> RequestedDevelopers { get; set; }

        public ICollection<ReceivedProjectRequest> ReceivedRequests { get; set; }
    }
}