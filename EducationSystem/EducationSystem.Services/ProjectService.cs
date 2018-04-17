using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using EducationSystem.Data;
using EducationSystem.Dtos.Project;
using EducationSystem.Models;
using EducationSystem.Models.Mappings;

namespace EducationSystem.Services
{
    public class ProjectService
    {
        private readonly EducationSystemDbContext ctx;

        public ProjectService()
        {
            ctx = new EducationSystemDbContext();
        }

        public Project GetById(int id)
        {
            using (ctx)
            {
                var project = ctx.Projects.FirstOrDefault(p => p.Id == id);
                return project;
            }
        }

        public ICollection<Project> GetByName(string name)
        {
            using (ctx)
            {
                var project = ctx.Projects.Where(p => p.Name.Contains(name)).ToList();
                return project;
            }
        }

        public ICollection<Project> GetAllNotOwnedByUser(string email)
        {
            using (ctx)
            {
                if (String.IsNullOrEmpty(email))
                {
                    return ctx.Projects.Include(p => p.ProductOwner).ToList();
                }
                var projects = ctx.Projects.Where(p => p.ProductOwner.Email != email).ToList();

                return projects;
            }
        }

        public ICollection<Project> GetAllCreatedByUser(string username)
        {
            using (ctx)
            {
                var projects = ctx.Projects.Include(p => p.ProductOwner)
                        .Where(p => p.ProductOwner.UserName == username).ToList();
                return projects;
            }

        }

        public ICollection<Project> GetAllRequestedByUser(string username)
        {
            using (ctx)
            {
                var requestedProjects = ctx.RequestedProjectRequests
                    .Where(rp => rp.Account.UserName == username).Include(ap => ap.Project)
                    .Select(rp => rp.Project)
                    .ToList();
                return requestedProjects;
            }
        }

        public ICollection<Project> GetAllReceivedByUser(string username)
        {
            using (ctx)
            {
                var requestedProjects = ctx.ReceivedProjectRequests
                    .Where(rp => rp.Account.UserName == username).Include(ap => ap.Project)
                    .Select(rp => rp.Project)
                    .ToList();
                return requestedProjects;
            }
        }

        public ICollection<Project> GetAllAcceptedByUser(string username)
        {
            using (ctx)
            {
                var requestedProjects = ctx.AcceptedProjectRequests
                    .Where(ap => ap.Account.UserName == username).Include(ap => ap.Project)
                    .Select(ap => ap.Project)
                    .ToList();
                return requestedProjects;
            }
        }

        public ICollection<Project> GetOpenedProjects()
        {
            using (ctx)
            {
                var projects = ctx.Projects.Where(p => p.StartDate == null).ToList();
                return projects;
            }
        }

        public ICollection<Project> GetProjectsInProgress()
        {
            using (ctx)
            {
                var projects = ctx.Projects
                    .Where(p => p.StartDate != null && p.EndDate == null)
                    .ToList();

                return projects;
            }
        }

        public ICollection<Project> GetFinishedProjects()
        {
            using (ctx)
            {
                var projects = ctx.Projects
                    .Where(p => p.StartDate != null && p.EndDate != null)
                    .ToList();

                return projects;
            }
        }

        public ICollection<Project> GetBySkillTypes(List<int> skillIds)
        {
            using (ctx)
            {
                var projects = ctx.Projects.Include(p => p.SkillsNeeded)
                    .Where(p => p.SkillsNeeded
                                .Any(s => skillIds.Contains(Convert.ToInt32(s.Type))))
                    .ToList();

                return projects;
            }
        }

        public void Create(CreateProjectDTO projectDto)
        {
            using (ctx)
            {
                var userId = ctx.Users.FirstOrDefault(u => u.Email == projectDto.UserEmail).Id;
                var project = GenerateModel(userId, projectDto);

                ctx.Projects.Add(project);
                ctx.SaveChanges();
            }
        }

        public void Edit(ProjectFilter filter)
        {
            using (ctx)
            {
                var project = ctx.Projects.FirstOrDefault(p => p.Id == filter.Id);
                project.Name = filter.Name;
                project.GitHubUrl = filter.GitHubUrl;
                project.StartDate = filter.StartDate;
                project.EndDate = filter.EndDate;
                project.Description = filter.Description;
                project.Requirements = filter.Requirements;
                project.IsTeamFormed = filter.StartDate != null;
                project.Resources = filter.Resources;
                project.SkillsNeeded = filter.SkillsNeeded;

                ctx.SaveChanges();
            }
        }

        public void AcceptUser(int projectId, string username)
        {
            using (ctx)
            {
                var project = ctx.Projects.Include(p => p.ReceivedRequests)
                                    .FirstOrDefault(p => p.Id == projectId);
                var user = ctx.Users.Include(u => u.RequestedProjects)
                                 .FirstOrDefault(u => u.UserName == username);

                if (project != null)
                {
                    var receivedRequest = project.ReceivedRequests.Where(u => u.Account != null).
                        FirstOrDefault(u => u.Account.UserName == username);

                    var receivedRequestForDelete = ctx.Entry(receivedRequest);
                    receivedRequestForDelete.State = EntityState.Deleted;

                    var requestedProject = user.RequestedProjects.
                        FirstOrDefault(u => u.ProjectId == projectId);

                    var requestedProjectForDelete = ctx.Entry(requestedProject);
                    requestedProjectForDelete.State = EntityState.Deleted;

                    user.AcceptedProjects.Add(
                        new AcceptedProjectRequest
                        {
                            AccountId = requestedProject.AccountId,
                            ProjectId = requestedProject.ProjectId
                        });

                    ctx.SaveChanges();
                }
            }
        }

        private static Project GenerateModel(string userId, CreateProjectDTO projectDto)
        {
            return new Project
            {
                Name = projectDto.Name,
                GitHubUrl = projectDto.GitHubUrl,
                Description = projectDto.Description,
                Requirements = projectDto.Requirements,
                SkillsNeeded = projectDto.SkillsNeeded,
                CreateDate = DateTime.Now,
                ProductOwnerId = userId
            };
        }
    }
}