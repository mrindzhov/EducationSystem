using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSystem.Models
{
    public class CreateProjectDTO
    {
        public string Name { get; set; }

        public string GitHubUrl { get; set; }

        public string Description { get; set; }

        public string Requirements { get; set; }

        public ICollection<Skill> SkillsNeeded { get; set; }
    }
}