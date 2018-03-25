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
    }
}