using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EducationSystem.Data;
using EducationSystem.Models;
using EducationSystem.Models.Enums;

namespace EducationSystem.Services
{
    public class FeedbackService
    {
        private readonly EducationSystemDbContext ctx;

        public FeedbackService()
        {
            ctx = new EducationSystemDbContext();
        }

        public Feedback GetById(int id)
        {
            using (ctx)
            {
                var feedback = ctx.Feedbacks.FirstOrDefault(p => p.Id == id);
                return feedback;
            }
        }
        public ICollection<Feedback> GetByUser(string userName)
        {
            using (ctx)
            {
                var feedbacks = ctx.Feedbacks.Include(f => f.User)
                    .Where(p => p.User.UserName == userName)
                    .ToList();
                return feedbacks;
            }
        }
        public ICollection<Feedback> GetByProject(int projectId)
        {
            using (ctx)
            {
                var feedbacks = ctx.Projects.Include(p => p.Feedbacks)
                    .Where(p => p.Id == projectId)
                    .FirstOrDefault()
                    .Feedbacks.ToList();
                return feedbacks;
            }
        }

        public void RateUserByItsProject(int projectId, string username, int rate, string comment)
        {
            using (ctx)
            {
                var user = ctx.Users.FirstOrDefault(x => x.UserName == username);
                var feedback = new Feedback()
                {
                    UserId = user.Id,
                    Comment = comment,
                    Rating = (FeedbackRating)rate
                };

                var project = ctx.Projects.Include(x => x.Feedbacks).FirstOrDefault(x => x.Id == projectId);
                project.Feedbacks.Add(feedback);
            }
        }
    }
}