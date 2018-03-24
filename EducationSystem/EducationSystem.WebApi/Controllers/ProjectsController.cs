using System.Web.Http;
using EducationSystem.Data;
using EducationSystem.Models;

namespace EducationSystem.WebApi.Controllers
{
    public class ProjectsController : ApiController
    {
        private EducationSystemDbContext db = new EducationSystemDbContext();

        public IHttpActionResult GetById(int id)
        {
            //var project = db.Projects.Find(id).FirstOrDefault;

            return Json("Hello");
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

        public IHttpActionResult CreateProject()
        {
            var project = new Project();
            return Json("");
        }
    }
}