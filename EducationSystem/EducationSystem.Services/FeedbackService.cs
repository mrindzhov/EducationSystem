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
        public Feedback GetById(int id)
        {
            using (EducationSystemDbContext db = new EducationSystemDbContext())
            {
                var feedback = db.Feedbacks.FirstOrDefault(p => p.Id == id);
                return feedback;
            }
        }
        public ICollection<Feedback> GetByUser(string userName)
        {
            using (EducationSystemDbContext db = new EducationSystemDbContext())
            {
                var feedbacks = db.Feedbacks.Include(f => f.User)
                    .Where(p => p.User.UserName == userName)
                    .ToList();
                return feedbacks;
            }
        }
        public ICollection<Feedback> GetByProject(int projectId)
        {
            using (EducationSystemDbContext db = new EducationSystemDbContext())
            {
                var feedbacks = db.Projects.Include(p => p.Feedbacks)
                    .Where(p => p.Id == projectId)
                    .FirstOrDefault()
                    .Feedbacks.ToList();
                return feedbacks;
            }
        }

        public void RateUserByItsProject(int projectId, string username, int rate, string comment)
        {
            using (EducationSystemDbContext db = new EducationSystemDbContext())
            {
                var user = db.Users.FirstOrDefault(x => x.UserName == username);
                var feedback = new Feedback()
                {
                    UserId = user.Id,
                    Comment = comment,
                    Rating = (FeedbackRating)rate
                };

                var project = db.Projects.Include(x=>x.Feedbacks).FirstOrDefault(x => x.Id == projectId);
                project.Feedbacks.Add(feedback);
            }
        }
    }
}