using System.Web.Http;
using System.Web.Http.Cors;
using EducationSystem.Services;

namespace EducationSystem.WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FeedbackController : ApiController
    {
        public IHttpActionResult GetById(int id)
        {
            var service = new FeedbackService();
            var feedback = service.GetById(id);

            return Json(feedback);
        }

        public IHttpActionResult GetByUser(string userName)
        {
            var service = new FeedbackService();
            var feedback = service.GetByUser(userName);

            return Json(feedback);
        }

        public IHttpActionResult GetByProject(int projectId)
        {
            var service = new FeedbackService();
            var feedback = service.GetByProject(projectId);

            return Json(feedback);
        }

        public IHttpActionResult RateUserByItsProject(int projectId, string username, int rate, string comment)
        {
            var service = new FeedbackService();
            try
            {
                service.RateUserByItsProject(projectId, username, rate, comment);
                return Ok();
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }
    }
}