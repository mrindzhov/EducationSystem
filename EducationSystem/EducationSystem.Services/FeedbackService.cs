using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EducationSystem.Data;
using EducationSystem.Models;

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

        public void RateUserByProject(string id)
        {

        }
    }
}