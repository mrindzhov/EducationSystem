using System.Web.Http;
using EducationSystem.Services;

namespace EducationSystem.WebApi.Controllers
{
    public class FeedbackController : ApiController
    {
        private readonly FeedbackService service;

        public FeedbackController()
        {
            service = new FeedbackService();
        }
        public IHttpActionResult GetById(int id)
        {
            var feedback = service.GetById(id);
            return Json(feedback);
        }

        public IHttpActionResult GetByUser(string userName)
        {
            var feedback = service.GetByUser(userName);
            return Json(feedback);
        }

        public IHttpActionResult GetByProject(int projectId)
        {
            var feedback = service.GetByProject(projectId);
            return Json(feedback);
        }

        public IHttpActionResult RateUserByItsProject(int projectId, string username, int rate, string comment)
        {
            service.RateUserByItsProject(projectId, username, rate, comment);
            return Ok();
        }
    }
}