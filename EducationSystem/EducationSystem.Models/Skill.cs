using System.Collections.Generic;
using EducationSystem.Models.Enums;

namespace EducationSystem.Models
{
    public class Skill
    {
        public Skill()
        {
            Feedbacks = new HashSet<Feedback>();
        }

        public int Id { get; set; }

        public SkillType Type { get; set; }

        public ICollection<Feedback> Feedbacks { get; set; }
    }
}
