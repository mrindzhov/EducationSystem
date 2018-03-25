using EducationSystem.Models.Enums;

namespace EducationSystem.Dtos.User
{
    public class SkillDto
    {
        public string UserName { get; set; }

        public int SkillType { get; set; }

        public SkillType GetSkillType()
        {
            return (SkillType)SkillType;
        }
    }
}
