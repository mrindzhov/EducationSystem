using System;
using System.Collections.Generic;
using System.Linq;
using EducationSystem.Data;
using EducationSystem.Dtos.Project;
using EducationSystem.Models;

namespace EducationSystem.Services
{
    public class ProjectService
    {
        public Project GetById(int id)
        {
            using (EducationSystemDbContext db = new EducationSystemDbContext())
            {
                var project = db.Projects.FirstOrDefault(p => p.Id == id);

                return project;
            }
        }

        public ICollection<Project> GetOpenedProjects()
        {
            using (EducationSystemDbContext db = new EducationSystemDbContext())
            {
                var projects = db.Projects.Where(p => p.StartDate == null).ToList();

                return projects;
            }
        }

        public ICollection<Project> GetProjectsInProgress()
        {
            using (EducationSystemDbContext db = new EducationSystemDbContext())
            {
                var projects = db.Projects.Where(p => p.StartDate != null && p.EndDate == null).ToList();

                return projects;
            }
        }

        public ICollection<Project> GetFinishedProjects()
        {
            using (EducationSystemDbContext db = new EducationSystemDbContext())
            {
                var projects = db.Projects.Where(p => p.StartDate != null && p.EndDate != null).ToList();

                return projects;
            }
        }

        public ICollection<Project> GetBySkillTypes(List<int> skillIds)
        {
            using (EducationSystemDbContext db = new EducationSystemDbContext())
            {
                var projects = db.Projects
                    .Where(p => p.SkillsNeeded
                                .Any(s => skillIds.Contains(Convert.ToInt32(s.Type))))
                    .ToList();

                return projects;
            }
        }

        public void Create(string userId, CreateProjectDTO project)
        {
            //Not tested for correct userId
            using (EducationSystemDbContext db = new EducationSystemDbContext())
            {
                var projectModel = new Project
                {
                    Name = project.Name,
                    GitHubUrl = project.GitHubUrl,
                    Description = project.Description,
                    Requirements = project.Requirements,
                    SkillsNeeded = project.SkillsNeeded,
                    CreateDate = DateTime.Now,
                    ProductOwnerId = userId
                };

                db.Projects.Add(projectModel);
                db.SaveChanges();
            }
        }

        public void Edit(ProjectFilter filter)
        {
            using (EducationSystemDbContext db = new EducationSystemDbContext())
            {
                var project = db.Projects.FirstOrDefault(p => p.Id == filter.Id);
                project.Name = filter.Name;
                project.GitHubUrl = filter.GitHubUrl;
                project.StartDate = filter.StartDate;
                project.EndDate = filter.EndDate;
                project.Description = filter.Description;
                project.Requirements = filter.Requirements;
                project.IsTeamFormed = filter.IsTeamFormed;
                project.Resources = filter.Resources;
                project.SkillsNeeded = filter.SkillsNeeded;

                db.SaveChanges();
            }
        }
    }
}