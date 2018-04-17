using EducationSystem.Data;
using EducationSystem.Dtos.User;
using EducationSystem.Models;
using EducationSystem.Models.Enums;
using EducationSystem.Models.Mappings;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EducationSystem.Services
{
    public class UserService
    {
        public User GetByUsername(string Username)
        {
            using (EducationSystemDbContext db = new EducationSystemDbContext())
            {
                var user = db.Users.FirstOrDefault(x => x.UserName == Username);
                return user;
            }
        }

        public string GetIdByUsername(string username)
        {
            using (EducationSystemDbContext db = new EducationSystemDbContext())
            {
                var user = db.Users.FirstOrDefault(x => x.UserName == username);
                return user.Id;
            }
        }

        public ICollection<User> GetAllUsersBySkill(int skillType, double minumRank = 2)
        {
            var usersWithSkill = new List<User>();

            using (EducationSystemDbContext db = new EducationSystemDbContext())
            {
                usersWithSkill = db.Users.Where(u => u.Skills.Any(s => s.Type == (SkillType)skillType)).ToList();
            }
            List<User> targetUsers = GetUsersWithMatchingRank(skillType, minumRank, usersWithSkill);

            return targetUsers;
        }

        public ICollection<User> GetParticipants(int projectId)
        {
            var project = new Project();

            using (EducationSystemDbContext db = new EducationSystemDbContext())
            {
                project = db.Projects.Include(p => p.AcceptedDevelopers).FirstOrDefault(p => p.Id == projectId);
            }

            var participants = project.AcceptedDevelopers?.Select(d => d.Account).ToList();

            return participants;
        }

        public ICollection<User> GetReceivedRequests(int projectId)
        {
            var project = new Project();

            using (EducationSystemDbContext db = new EducationSystemDbContext())
            {
                project = db.Projects.Include(p => p.ReceivedRequests).FirstOrDefault(p => p.Id == projectId);
            }

            var receivedRequests = project.ReceivedRequests?.Select(d => d.Account).ToList();

            return receivedRequests;
        }

        public ICollection<User> GetRequestedDevelopers(int projectId)
        {
            var project = new Project();

            using (EducationSystemDbContext db = new EducationSystemDbContext())
            {
                project = db.Projects.Include(p => p.RequestedDevelopers).FirstOrDefault(p => p.Id == projectId);
            }

            var participants = project.RequestedDevelopers?.Select(d => d.Account).ToList();

            return participants;
        }

        public void SendRequestToProject(string username, int projectId)
        {
            using (EducationSystemDbContext db = new EducationSystemDbContext())
            {
                var user = db.Users.Include(x => x.RequestedProjects).FirstOrDefault(x => x.UserName == username);
                var project = db.Projects.Include(x => x.ReceivedRequests).FirstOrDefault(x => x.Id == projectId);
                if (user != null && project != null)
                {
                    var userRequest = new RequestedProjectRequest()
                    {
                        AccountId =user.Id,
                        ProjectId = projectId
                    };

                    var projectRequest = new ReceivedProjectRequest()
                    {
                        ProjectId = projectId,
                        AccountId = user.Id
                    };

                    user.RequestedProjects.Add(userRequest);
                    project.ReceivedRequests.Add(projectRequest);

                    db.SaveChanges();
                }
            }
        }

        public void AddSkill(SkillDto skillDto)
        {
            using (EducationSystemDbContext db = new EducationSystemDbContext())
            {
                var user = db.Users.Include(x => x.Skills).FirstOrDefault(x => x.UserName == skillDto.UserName);

                var skill = new Skill()
                {
                    Type = skillDto.GetSkillType()
                };

                user.Skills.Add(skill);
                db.SaveChanges();
            }
        }

        private static List<User> GetUsersWithMatchingRank(int skillType, double minumRank, List<User> usersWithSkill)
        {
            var targetUsers = new List<User>();
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

        public void AcceptProject(int projectId, string username)
        {
            using (EducationSystemDbContext db = new EducationSystemDbContext())
            {
                var user = db.Users.Include(x => x.ReceivedProjectRequests).FirstOrDefault(x => x.UserName == username);
                var project = db.Projects.Include(x => x.RequestedDevelopers).FirstOrDefault(x => x.Id == projectId);
                if (user != null && project!=null)
                {
                    var userRequest = user.ReceivedProjectRequests
                        .FirstOrDefault(x => x.ProjectId == projectId && x.Account.UserName == username);

                    var projectRequest = project.RequestedDevelopers
                        .FirstOrDefault(x => x.ProjectId == projectId && x.Account.UserName == username);

                    user.ReceivedProjectRequests.Remove(userRequest);
                    project.RequestedDevelopers.Remove(projectRequest);

                    user.AcceptedProjects.Add(new AcceptedProjectRequest()
                    {
                        AccountId = userRequest.AccountId,
                        ProjectId = userRequest.ProjectId
                    });

                    project.AcceptedDevelopers.Add(new AcceptedProjectRequest()
                    {
                        AccountId = projectRequest.AccountId,
                        ProjectId = projectRequest.ProjectId
                    });

                    db.SaveChanges();
                }
            }
        }

        public void DeclineProject(int projectId, string username)
        {
            using (EducationSystemDbContext db = new EducationSystemDbContext())
            {
                var user = db.Users.Include(x => x.ReceivedProjectRequests).FirstOrDefault(x => x.UserName == username);
                var project = db.Projects.Include(x => x.RequestedDevelopers).FirstOrDefault(x => x.Id == projectId);

                if (user != null)
                {
                    var userRequest = user.ReceivedProjectRequests
                        .FirstOrDefault(x => x.ProjectId == projectId && x.Account.UserName == username);
                    var projectRequest = project.RequestedDevelopers
                        .FirstOrDefault(x => x.ProjectId == projectId && x.Account.UserName == username);

                    user.ReceivedProjectRequests.Remove(userRequest);
                    project.RequestedDevelopers.Remove(projectRequest);

                    db.SaveChanges();
                }
            }
        }
    }
}