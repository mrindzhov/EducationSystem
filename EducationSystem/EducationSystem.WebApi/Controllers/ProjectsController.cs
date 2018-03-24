using System.Web.Http;
using EducationSystem.Data;
using EducationSystem.Models;
using System.Web.Http.Cors;
using Microsoft.AspNet.Identity;
using System.Linq;
using System;
using System.Collections.Generic;
using EducationSystem.Dtos.Project;

namespace EducationSystem.WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProjectsController : ApiController
    {
        public IHttpActionResult GetById(int id)
        {
            using (EducationSystemDbContext db = new EducationSystemDbContext())
            {
                var project = db.Projects.Find(id);

                if (project == null)
                {
                    return NotFound();
                }

                return Json(project);
            }
        }

        public IHttpActionResult GetOpenedProjects()
        {
            using (EducationSystemDbContext db = new EducationSystemDbContext())
            {
                var projects = db.Projects.Where(p => p.StartDate == null).ToList();

                if (projects.Count == 0)
                {
                    return NotFound();
                }

                return Json(projects);
            }
        }

        public IHttpActionResult GetProjectsInProgress()
        {
            using (EducationSystemDbContext db = new EducationSystemDbContext())
            {
                var projects = db.Projects.Where(p => p.StartDate != null && p.EndDate == null).ToList();

                if (projects.Count == 0)
                {
                    return NotFound();
                }

                return Json(projects);
            }
        }

        public IHttpActionResult GetFinishedProjects()
        {
            using (EducationSystemDbContext db = new EducationSystemDbContext())
            {
                var projects = db.Projects.Where(p => p.StartDate != null && p.EndDate != null).ToList();

                if (projects.Count == 0)
                {
                    return NotFound();
                }

                return Json(projects);
            }
        }

        public IHttpActionResult GetBySkillTypes(List<int> skillIds)
        {
            using (EducationSystemDbContext db = new EducationSystemDbContext())
            {
                var projects = db.Projects
                    .Where(p => p.SkillsNeeded
                                .Any(s => skillIds.Contains(Convert.ToInt32(s.Type))))
                    .ToList();

                if (projects.Count == 0)
                {
                    return NotFound();
                }

                return Json(projects);
            }
        }

        [HttpPost]
        public IHttpActionResult Create(CreateProjectDTO proj)
        {
            //Not tested for correct userId
            using (EducationSystemDbContext db = new EducationSystemDbContext())
            {
                //var mmm = Membership.GetUser(User.Identity.Name).ProviderUserKey;
                var userId = int.Parse(User.Identity.GetUserId());

                try
                {
                    var project = new Project
                    {
                        Name = proj.Name,
                        GitHubUrl = proj.GitHubUrl,
                        Description = proj.Description,
                        Requirements = proj.Requirements,
                        SkillsNeeded = proj.SkillsNeeded,
                        CreateDate = DateTime.Now,
                        ProductOwnerId = userId
                    };

                    db.Projects.Add(project);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    return BadRequest();
                }

                return Ok();
            }
        }

        [HttpPost]
        public IHttpActionResult Edit(ProjectFilter filter)
        {
            return Json("");
        }
    }
}