using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace SierraPacific.Api.Controllers
{
    [Authorize]
    [RoutePrefix("api/Secure")]
    public class SecureController : ApiController
    {
        public HttpResponseMessage Get()
        {
            //var identity = User.Identity as ClaimsIdentity;
            var claims = ((ClaimsPrincipal)User).Claims;

            var sessionId = claims.First(c => c.Type == "SierraPacific.Identity.Legacy.Sessionid");

            return Request.CreateResponse(HttpStatusCode.OK, "Your session id is " + sessionId.Value);
        }
    }
}
