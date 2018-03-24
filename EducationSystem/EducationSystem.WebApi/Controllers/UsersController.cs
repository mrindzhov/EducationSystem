using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EducationSystem.WebApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class UsersController : ApiController
    {
        private static List<object> messages =
            new List<object>()
            {
                new
                {
                    AuthorTwitterHandle = "Pusher",
                    Text = "Hi there! 😘"
                },
                new
                {
                    AuthorTwitterHandle = "Pusher",
                    Text = "Welcome to your chat app"
                }
            };

        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, messages);
        }

        public IHttpActionResult Post(object message)
        {
            var obj = new { mina = true };
            return Json(obj);
        }
    }
}
