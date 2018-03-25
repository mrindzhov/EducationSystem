using System.Web.Http;
using System.Web.Http.Cors;
using EducationSystem.Services;

namespace EducationSystem.WebApi.Controllers
{
    [Authorize]
    [EnableCors("*", "*", "*")]
    public class UsersController : ApiController
    {
        public IHttpActionResult GetByUsername(string username)
        {
            var service = new UserService();
            var user = service.GetByUsername(username);

            return Json(user);
        }

        public IHttpActionResult GetAllUsersBySkill(int skillType, double minumRank)
        {
            var service = new UserService();
            var users = service.GetAllUsersBySkill(skillType, minumRank);

            return Json(users);
        }

        public IHttpActionResult GetParticipants(int id)
        {
            var service = new UserService();
            var participants = service.GetParticipants(id);

            return Json(participants);
        }

        public IHttpActionResult GetReceivedRequests(int id)
        {
            var service = new UserService();
            var receivedRequests = service.GetReceivedRequests(id);

            return Json(receivedRequests);
        }

        public IHttpActionResult GetRequestedDevelopers(int id)
        {
            var service = new UserService();
            var requestedDevelopers = service.GetRequestedDevelopers(id);

            return Json(requestedDevelopers);
        }
    }
}