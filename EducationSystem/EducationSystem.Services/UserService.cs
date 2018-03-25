using EducationSystem.Data;
using EducationSystem.Models;
using EducationSystem.Models.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSystem.Services
{
    public class UserService
    {
        public ApplicationUser GetByUsername(string Username)
        {
            using (EducationSystemDbContext db = new EducationSystemDbContext())
            {
                var user = db.Users.FirstOrDefault(x => x.UserName == Username);
                return user;
            }
        }

        public ICollection<ApplicationUser> GetAllUsersBySkill(int skillType, double minumRank = 2)
        {
            var usersWithSkill = new List<ApplicationUser>();

            using (EducationSystemDbContext db = new EducationSystemDbContext())
            {
                usersWithSkill = db.Users.Where(u => u.Skills.Any(s => s.Type == (SkillType)skillType)).ToList();
            }
            List<ApplicationUser> targetUsers = GetUsersWithMatchingRank(skillType, minumRank, usersWithSkill);

            return targetUsers;
        }

        public ICollection<ApplicationUser> GetParticipants(int projectId)
        {
            var project = new Project();

            using (EducationSystemDbContext db = new EducationSystemDbContext())
            {
                project = db.Projects.Include(p => p.AcceptedDevelopers).FirstOrDefault(p => p.Id == projectId);
            }

            var participants = project.AcceptedDevelopers?.Select(d => d.Account).ToList();

            return participants;
        }

        public ICollection<ApplicationUser> GetReceivedRequests(int projectId)
        {
            var project = new Project();

            using (EducationSystemDbContext db = new EducationSystemDbContext())
            {
                project = db.Projects.Include(p => p.ReceivedRequests).FirstOrDefault(p => p.Id == projectId);
            }

            var receivedRequests = project.ReceivedRequests?.Select(d => d.Account).ToList();

            return receivedRequests;
        }

        public ICollection<ApplicationUser> GetRequestedDevelopers(int projectId)
        {
            var project = new Project();

            using (EducationSystemDbContext db = new EducationSystemDbContext())
            {
                project = db.Projects.Include(p => p.RequestedDevelopers).FirstOrDefault(p => p.Id == projectId);
            }

            var participants = project.RequestedDevelopers?.Select(d => d.Account).ToList();

            return participants;
        }

        private static List<ApplicationUser> GetUsersWithMatchingRank(int skillType, double minumRank, List<ApplicationUser> usersWithSkill)
        {
            var targetUsers = new List<ApplicationUser>();
            foreach (var user in usersWithSkill)
            {
                Skill targetSkill = user.Skills.FirstOrDefault(s => s.Type == (SkillType)skillType);
                double sumRating = 0;
                int count = 0;

                foreach (var feedback in targetSkill.Feedbacks)
                {
                    sumRating += (double)feedback.Rating;
                    count++;
                }

                var averageRank = sumRating / count;

                if (averageRank > minumRank)
                {
                    targetUsers.Add(user);
                }
            }

            return targetUsers;
        }
    }
}