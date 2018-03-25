using EducationSystem.Models;
using System.Collections.Generic;

namespace EducationSystem.Dtos.Project
{
    public class CreateProjectDTO
    {
        public string UserEmail { get; set; }

        public string Name { get; set; }

        public string GitHubUrl { get; set; }

        public string Description { get; set; }

        public string Requirements { get; set; }

        public ICollection<Skill> SkillsNeeded { get; set; }
    }
}