﻿using System;
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
        public Project GetById(int id)
        {
            using (EducationSystemDbContext db = new EducationSystemDbContext())
            {
                var project = db.Projects.FirstOrDefault(p => p.Id == id);

                return project;
            }
        }

        public ICollection<Project> GetByName(string name)
        {
            using (EducationSystemDbContext db = new EducationSystemDbContext())
            {
                var project = db.Projects.Where(p => p.Name.Contains(name)).ToList();

                return project;
            }
        }

        public ICollection<Project> GetAll(string email)
        {
            using (EducationSystemDbContext db = new EducationSystemDbContext())
            {
                if (String.IsNullOrEmpty(email))
                {
                    return db.Projects.Include(p => p.ProductOwner).ToList();
                }

                var projects = db.Projects;//.Include(p => p.ProductOwner).ToList();
                var sss = projects.Where(p => p.ProductOwner.Email != email).ToArray();

                return sss;
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
                var projects = db.Projects.Where(p => p.StartDate != null
                                                   && p.EndDate == null)
                               .ToList();

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
                var projects = db.Projects.Include(p => p.SkillsNeeded)
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
                var projectModel = new Project();
                projectModel.Name = project.Name;
                projectModel.GitHubUrl = project.GitHubUrl;
                projectModel.Description = project.Description;
                projectModel.Requirements = project.Requirements;
                projectModel.SkillsNeeded = project.SkillsNeeded;
                projectModel.CreateDate = DateTime.Now;
                projectModel.ProductOwnerId = userId;

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
                project.IsTeamFormed = filter.StartDate != null ? true : false;
                project.Resources = filter.Resources;
                project.SkillsNeeded = filter.SkillsNeeded;

                db.SaveChanges();
            }
        }

        public ICollection<Project> GetUserProjects(string username)
        {
            var user = new ApplicationUser();
            var projects = new List<Project>();

            using (EducationSystemDbContext db = new EducationSystemDbContext())
            {
                user = db.Users.FirstOrDefault(u => u.UserName == username);
                projects = db.Projects.Where(p => p.ProductOwnerId == user.Id).ToList();
            }

            return projects;
        }

        public void AcceptUser(int projectId, string username)
        {
            var project = new Project();
            var user = new ApplicationUser();

            using (EducationSystemDbContext db = new EducationSystemDbContext())
            {
                project = db.Projects.Include(p => p.ReceivedRequests)
                    .FirstOrDefault(p => p.Id == projectId);
                user = db.Users.Include(u => u.RequestedProjects)
                    .FirstOrDefault(u => u.UserName == username);

                if (project != null)
                {
                    var receivedRequest = project.ReceivedRequests.
                        FirstOrDefault(u => u.Account.UserName == username);

                    project.ReceivedRequests.Remove(receivedRequest);
                    project.AcceptedDevelopers.Add(new AcceptedProjectRequest
                    { AccountId = receivedRequest.AccountId, ProjectId = receivedRequest.ProjectId });

                    var requestedProject = user.RequestedProjects.
                        FirstOrDefault(u => u.ProjectId == projectId);

                    user.RequestedProjects.Remove(requestedProject);
                    user.AcceptedProjects.Add(new AcceptedProjectRequest
                    { AccountId = requestedProject.AccountId, ProjectId = requestedProject.ProjectId });

                    db.SaveChanges();
                }
            }
        }
    }
}