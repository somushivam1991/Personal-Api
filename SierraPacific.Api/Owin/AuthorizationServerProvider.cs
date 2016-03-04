using Microsoft.Owin.Security.OAuth;
using SierraPacific.Bootstrapper;
using SierraPacific.Core.Models;
using SierraPacific.Core.Service;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SierraPacific.Api.Owin
{
    /// <summary>
    /// 
    /// https://msdn.microsoft.com/en-us/library/microsoft.owin.security.oauth.oauthauthorizationserverprovider(v=vs.113).aspx
    /// </summary>
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly ISampleService sampleService;
        public AuthorizationServerProvider()
        {
            this.sampleService = ApiDependencyResolver.Resolve<ISampleService>();
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // To Do: if we have the concept of client (client id, secret etc); validation should be done here.
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            // context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            var user = new User
            {
                Name = context.UserName,
                Password = context.Password,
            };
            var sessionId = sampleService.GetSessionId(user);

            if (string.IsNullOrWhiteSpace(sessionId))
            {
                context.SetError("invalid_grant", "Wrong credentials.");
                context.Rejected();
            }

            //var authProps = new AuthenticationProperties(new Dictionary<string, string>
            //{
            //    { "SierraPacific.Identity.Legacy.Sessionid", sessionId },
            //});

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("SierraPacific.Identity.UserName", context.UserName));
            identity.AddClaim(new Claim("SierraPacific.Identity.Legacy.Sessionid", sessionId));

            // issue the token
            //context.Validated(new AuthenticationTicket(identity, authProps));
            context.Validated(identity);


        }

        //public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        //{      

        //    foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
        //    {
        //        context.AdditionalResponseParameters.Add(property.Key, property.Value);
        //    }

        //    return Task.FromResult<object>(null);
        //}
    }
}