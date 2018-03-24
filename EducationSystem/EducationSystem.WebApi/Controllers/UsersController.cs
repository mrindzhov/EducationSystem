using EducationSystem.Data;
using EducationSystem.Dtos.Project;
using EducationSystem.Models;
using EducationSystem.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EducationSystem.WebApi.Controllers
{
    [Authorize]
    [EnableCors("*","*","*")]
    public class UsersController : ApiController
    {
        public IHttpActionResult GetByUsername(string username)
        {
            var service = new UserService();
            return Json(service.GetByUsername(username));
        }

        public IHttpActionResult GetAllUsersBySkill(int skillType, double minumRank)
        {
            var service = new UserService();
            return Json(service.GetAllUsersBySkill(skillType, minumRank));
        }

        //public IHttpActionResult GetUserProjects(string username)
        //{
        //    
        //}

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
                    var project = new Project()
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
