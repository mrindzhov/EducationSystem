using System.Web.Http;
using System.Web.Http.Cors;
using EducationSystem.Services;
using EducationSystem.Dtos.User;

namespace EducationSystem.WebApi.Controllers
{
    //[Authorize]
    public class UserController : AbstractApiController
    {
        public IHttpActionResult GetByUsername(string username)
        {
            var service = new UserService();
            var user = service.GetByUsername(username);

            return Json(user);
        }

        public IHttpActionResult GetIdByUsername(string username)
        {
            var service = new UserService();
            string user;
            try
            {
                 user = service.GetIdByUsername(username);
            }
            catch (System.Exception)
            {

                throw;
            }
            return Json(user);
        }

        public IHttpActionResult GetAllUsersBySkill(int skillType, double minumRank)
        {
            var service = new UserService();
            var users = service.GetAllUsersBySkill(skillType, minumRank);

            return Json(users);
        }

        public IHttpActionResult GetParticipants(int projectId)
        {
            var service = new UserService();
            var participants = service.GetParticipants(projectId);

            return Json(participants);
        }

        public IHttpActionResult GetReceivedRequests(int projectId)
        {
            var service = new UserService();
            var receivedRequests = service.GetReceivedRequests(projectId);

            return Json(receivedRequests);
        }

        public IHttpActionResult GetRequestedDevelopers(int projectId)
        {
            var service = new UserService();
            var requestedDevelopers = service.GetRequestedDevelopers(projectId);

            return Json(requestedDevelopers);
        }

        public IHttpActionResult AcceptProject(int projectId, string username)
        {
            var service = new UserService();
            try
            {
                service.AcceptProject(projectId, username);
                return Ok();
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }

        public IHttpActionResult DeclineProject(int projectId, string username)
        {
            var service = new UserService();
            try
            {
                service.DeclineProject(projectId, username);
                return Ok();
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }

        public IHttpActionResult SendRequestToProject(string username, int projectId)
        {
            var service = new UserService();
            try
            {
                service.SendRequestToProject(username, projectId);
                return Ok();
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }

        public IHttpActionResult AddSkill(SkillDto skillDto)
        {
            var service = new UserService();
            try
            {
                service.AddSkill(skillDto);
                return Ok();
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }
    }
}