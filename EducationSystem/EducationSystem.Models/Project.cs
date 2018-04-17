using System;
using System.Collections.Generic;
using EducationSystem.Models.Mappings;

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

        public DateTime? EstimationDate { get; set; }

        public string Description { get; set; }

        public string Requirements { get; set; }

        public bool IsTeamFormed { get; set; }

        public string ProductOwnerId { get; set; }

        public User ProductOwner { get; set; }

        public ICollection<Feedback> Feedbacks { get; set; }

        public ICollection<Resource> Resources { get; set; }

        public ICollection<Skill> SkillsNeeded { get; set; }

        public ICollection<AcceptedProjectRequest> AcceptedDevelopers { get; set; }

        public ICollection<RequestedProjectRequest> RequestedDevelopers { get; set; }

        public ICollection<ReceivedProjectRequest> ReceivedRequests { get; set; }
    }
}