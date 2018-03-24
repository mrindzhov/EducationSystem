using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EducationSystem.Models.Enums;
using EducationSystem.Data;

namespace EducationSystem.WebApi.Controllers
{
    public class ProjectsController : ApiController
    {
        private EducationSystemDbContext db = new EducationSystemDbContext();

        public IHttpActionResult GetById(int id)
        {
            //var project = db.Projects.Find(id).FirstOrDefault;

            return Json("");
        }

        public IHttpActionResult GetOpenedProjects()
        {
            return Json("");
        }

        public IHttpActionResult GetProjectsInProgress()
        {
            return Json("");
        }

        public IHttpActionResult GetFinishedProjects()
        {
            return Json("");
        }

        public IHttpActionResult GetByTechnology(int techId)
        {
            //var technology = (SpkillType)techId;

            return Json("");
        }
    }
}