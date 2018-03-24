using System.Web.Http;
using EducationSystem.Data;
using EducationSystem.Models;
using System.Web.Http.Cors;
using System.Linq;
using EducationSystem.Models.Enums;
using System;
using System.Collections;
using System.Collections.Generic;

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
            var project = new Project();
            return Json("");
        }
    }
}