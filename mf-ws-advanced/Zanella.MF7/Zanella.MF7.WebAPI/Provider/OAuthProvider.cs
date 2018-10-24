using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Zanella.MF7.Aplicacao.Features.Authentication;
using Zanella.MF7.Dominio.Features.Users;
using Zanella.MF7.WebAPI.IoC;

namespace Zanella.MF7.WebAPI.Provider
{
    public class OAuthProvider : OAuthAuthorizationServerProvider
    {
        public OAuthProvider() : base()
        {
        }
             
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();

            return Task.FromResult<object>(null);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            var user = default(User);

            try
            {
                var authService = SimpleInjectorContainer.ContainerInstance.GetInstance<IAuthenticationService>();
                user = authService.Login(context.UserName, context.Password);
            }
            catch (Exception ex)
            {
                context.SetError("invalid_grant", ex.Message);
                return Task.FromResult<object>(null);
            }
            var identity = new ClaimsIdentity("JWT");
            identity.AddClaim(new Claim("UserId", user.Id.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
            identity.AddClaim(new Claim(ClaimTypes.Name, user.Name));
            var ticket = new AuthenticationTicket(identity, null);
            context.Validated(ticket);

            return Task.FromResult<object>(null);
        }
    }
}