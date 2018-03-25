using EducationSystem.Models.Enums;

namespace EducationSystem.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        public FeedbackRating Rating { get; set; }

        public string Comment { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}