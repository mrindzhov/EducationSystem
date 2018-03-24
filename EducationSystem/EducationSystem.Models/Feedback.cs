using EducationSystem.Models.Enums;

namespace EducationSystem.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        public FeedbackRating Rating { get; set; }

        public int UserId { get; set; }
        public ApplicationUser User { get; set; }

    }
}
