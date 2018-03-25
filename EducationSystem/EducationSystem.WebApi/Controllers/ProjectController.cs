using System;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using EducationSystem.Dtos.Project;
using EducationSystem.Services;

namespace EducationSystem.WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProjectController : ApiController
    {
        public IHttpActionResult GetById(int id)
        {
            var service = new ProjectService();
            var project = service.GetById(id);

            if (project == null)
            {
                return NotFound();
            }

            return Json(project);
        }

        public IHttpActionResult GetAllNotOwnedByUser(string email)
        {
            var service = new ProjectService();
            var projects = service.GetAll(email);

            return Json(projects);
        }

        public IHttpActionResult GetAllOpen()
        {
            var service = new ProjectService();
            var projects = service.GetOpenedProjects();

            return Json(projects);
        }

        public IHttpActionResult GetAllInProgress()
        {
            var service = new ProjectService();
            var projects = service.GetProjectsInProgress();

            return Json(projects);
        }

        public IHttpActionResult GetAllFinished()
        {
            var service = new ProjectService();
            var projects = service.GetFinishedProjects();

            return Json(projects);
        }

        public IHttpActionResult GetBySkillTypes(List<int> skillIds)
        {
            var service = new ProjectService();
            var projects = service.GetBySkillTypes(skillIds);

            return Json(projects);
        }

        [HttpPost]
        public IHttpActionResult Create(CreateProjectDTO project, string userEmail)
        {
            try
            {
                var service = new ProjectService();
                service.Create(userEmail, project);

                return Ok();
            }
            catch (Exception e)
            {
                var message = e.Message;
                return BadRequest();
            }
        }

        [HttpPost]
        public IHttpActionResult Edit(ProjectFilter filter)
        {
            try
            {
                var userId = User.Identity.GetUserId();
                var service = new ProjectService();
                service.Edit(filter);

                return Ok();
            }
            catch (Exception e)
            {
                var message = e.Message;
                return BadRequest();
            }
        }

        public IHttpActionResult GetAllByUser(string username)
        {
            var service = new ProjectService();
            var projects = service.GetUserProjects(username);

            return Json(projects);
        }

        [HttpPost]
        public IHttpActionResult AcceptUser(int projectId, string username)
        {
            try
            {
                var service = new ProjectService();
                service.AcceptUser(projectId, username);

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}