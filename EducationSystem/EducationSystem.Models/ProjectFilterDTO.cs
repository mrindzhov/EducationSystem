using EducationSystem.Models.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSystem.Models
{
    public class ProjectFilterDTO
    {
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