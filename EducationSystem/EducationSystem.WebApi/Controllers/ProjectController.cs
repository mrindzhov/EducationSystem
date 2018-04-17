using System;
using System.Web.Http;
using System.Collections.Generic;
using EducationSystem.Dtos.Project;
using EducationSystem.Services;

namespace EducationSystem.WebApi.Controllers
{
    public class ProjectController : AbstractApiController
    {
        private readonly ProjectService service;

        public ProjectController()
        {
            service = new ProjectService();
        }

        public IHttpActionResult GetById(int id)
        {
            var project = service.GetById(id);

            if (project == null)
            {
                return NotFound();
            }

            return Json(project);
        }

        public IHttpActionResult GetAllOpen()
        {
            var projects = service.GetOpenedProjects();
            return Json(projects);
        }

        public IHttpActionResult GetAllInProgress()
        {
            var projects = service.GetProjectsInProgress();
            return Json(projects);
        }

        public IHttpActionResult GetAllFinished()
        {
            var projects = service.GetFinishedProjects();
            return Json(projects);
        }

        public IHttpActionResult GetAllCreatedByUser(string username)
        {
            var projects = service.GetAllCreatedByUser(username);
            return Json(projects);
        }

        public IHttpActionResult GetAllAcceptedByUser(string username)
        {
            var projects = service.GetAllAcceptedByUser(username);
            return Json(projects);
        }

        public IHttpActionResult GetAllReceivedByUser(string username)
        {
            var projects = service.GetAllReceivedByUser(username);
            return Json(projects);
        }

        public IHttpActionResult GetAllRequestedByUser(string username)
        {
            var projects = service.GetAllRequestedByUser(username);
            return Json(projects);
        }

        public IHttpActionResult GetAllNotOwnedByUser(string email)
        {
            var projects = service.GetAllNotOwnedByUser(email);
            return Json(projects);
        }

        public IHttpActionResult GetBySkillTypes(List<int> skillIds)
        {
            var projects = service.GetBySkillTypes(skillIds);
            return Json(projects);
        }

        [HttpPost]
        public IHttpActionResult Create(CreateProjectDTO project)
        {
            try
            {
                service.Create(project);
                return Ok();
            }
            catch (Exception e)
            {
                var message = e.Message;
                return BadRequest(message);
            }
        }

        [HttpPost]
        public IHttpActionResult Edit(ProjectFilter filter)
        {
            try
            {
                service.Edit(filter);
                return Ok();
            }
            catch (Exception e)
            {
                var message = e.Message;
                return BadRequest(message);
            }
        }

        [HttpPost]
        public IHttpActionResult AcceptUser(int projectId, string username)
        {
            try
            {
                service.AcceptUser(projectId, username);
                return Ok();
            }
            catch (Exception e)
            {
                var message = e.Message;
                return BadRequest(message);
            }
        }
    }
}