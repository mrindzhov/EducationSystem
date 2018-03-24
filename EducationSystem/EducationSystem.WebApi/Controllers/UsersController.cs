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
    }
}