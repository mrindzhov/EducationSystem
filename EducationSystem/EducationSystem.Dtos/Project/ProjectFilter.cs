using EducationSystem.Models;
using System;
using System.Collections.Generic;

namespace EducationSystem.Dtos.Project
{
    public class ProjectFilter
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string GitHubUrl { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Description { get; set; }

        public string Requirements { get; set; }

        public bool IsTeamFormed { get; set; }

        public ICollection<Resource> Resources { get; set; }

        public ICollection<Skill> SkillsNeeded { get; set; }
    }
}