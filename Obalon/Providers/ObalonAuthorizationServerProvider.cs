
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Diagnostics;
//using System.Security.Claims;
//using System.Threading.Tasks;
//using System.Web;
//using Microsoft.Owin.Security;
//using Microsoft.Owin.Security.OAuth;
//using stdole;
////using SICAP.Web.Domain.Security;
////using SICAP.Web.Model.Security;

//namespace Obalon.Security
//{
//    public class ObalonAuthorizationServerProvider : OAuthAuthorizationServerProvider
//    {
//        //readonly IUserService _userService;
//        readonly ITokenManager _tokenManager;

//        public ObalonAuthorizationServerProvider(IUserService userService, ITokenManager tokenManager)
//        {
//            //_userService = userService;
//            _tokenManager = tokenManager;
//        }

//        /// <summary>
//        /// "client_id" and "client_secret" as form encoded POST parameters in request body
//        /// </summary>
//        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
//        {
//            _userService.CheckSessionExists();
            
//            string clientId;
//            string clientSecret;
//            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
//                context.TryGetFormCredentials(out clientId, out clientSecret);
           
//            // need to login
//            if (context.ClientId == null)
//            {
//                Debug.WriteLine("*** AUTH PROVIDER - ValidateClient -> VALIDATED " + clientId);
//                context.Validated();
//                return Task.FromResult<object>(null);
//            }

//            // addded this
//            var ticketId = context.Parameters["refresh_token"];
//            var token = _tokenManager.GetRefreshToken(ticketId);
//            if (token == null)
//            {
//                context.SetError("invalid_clientId", string.Format("Client '{0}' is not registered in the system.", context.ClientId));
//                Debug.WriteLine("*** AUTH PROVIDER - ValidateClient() -> REJECTED");
//                context.Rejected();
//                return Task.FromResult<object>(null);
//            }

//            context.OwinContext.Set("TKT", token);
//            context.OwinContext.Set("as:client_id", clientId);

//            Debug.WriteLine("*** AUTH PROVIDER - ValidateClient() -> VALIDATED " + token);
//            context.Validated();
//            return Task.FromResult<object>(null);
//        }

//        public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
//        {
//            //var originalClient = context.Ticket.Properties.Dictionary["as:client_id"];
//            //var currentClient = context.ClientId;
//            //if (originalClient != currentClient)
//            //{
//            //    context.SetError("invalid_clientId", "Refresh token is issued to a different clientId.");
//            //    return Task.FromResult<object>(null);
//            //}

//            // Change auth ticket for refresh token requests
//            var newIdentity = new ClaimsIdentity(context.Ticket.Identity);
//            var newTicket = new AuthenticationTicket(newIdentity, context.Ticket.Properties);
//            context.Validated(newTicket);
//            Debug.WriteLine("*** AUTH PROVIDER - GrantRefreshToken() VALIDATED " + newTicket.Identity.Name);

//            return Task.FromResult<object>(null);
//        }

//        /// <summary>
//        /// Method is called when client authenticates using QRCode (calls /token endpoint with parametters: grant_type=QRCODE)
//        /// </summary>
//        public override Task GrantCustomExtension(OAuthGrantCustomExtensionContext context)
//        {
//            switch (context.Parameters["grant_type"])
//            {
//                case "qrcode":
//                    var user = _userService.CurrentSession.QRCodeUser;
//                    GrantUser(user, context);
//                    break;

//                case "winjob":
//                    var usr = _userService.AuthenticateInternal("123").Result;
//                    GrantUser(usr, context);
//                    break;

//                default:
//                    context.SetError("invalid_grant", "Unknown grant type");
//                    break; 
//            }

//            return Task.FromResult<object>(null);
//        }

//        /// <summary>
//        /// Method is called when client authenticates using user and pass (calls /token endpoint with parametters:  grant_type=password&username=XXX&password=YYYY)
//        /// </summary>
//        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
//        {
//            //context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
//            var user = await _userService.Authenticate(context.UserName, context.Password);
            
//            GrantUser(user, context);

//            // check if QR code auth need to map certificate with user
//            _userService.CheckQRCodeCertMap(user);
//        }

//        void GrantUser(Common.Security.User user, BaseValidatingTicketContext<OAuthAuthorizationServerOptions> context)
//        {
//            if (user == null)
//            {
//                Debug.WriteLine("*** AUTH PROVIDER - GrantResourceOwnerCredentials() -> invalid_grant");
//                context.SetError("invalid_grant", "The user name or password is incorrect.");
//                return;
//            }

//            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
//            identity.AddClaim(new Claim("sub", user.Username));
//            identity.AddClaim(new Claim("UserID", user.UserId.ToString()));
//            identity.AddClaim(new Claim("Username", user.Username));
//            identity.AddClaim(new Claim("FullName", user.FullName));
//            identity.AddClaim(new Claim("UserSessionID", user.UserSessionId.ToString()));
//            identity.AddClaim(new Claim("EntityID", user.Entity.EntityID.ToString()));
//            identity.AddClaim(new Claim("EntityName", user.Entity.EntityName));
//            identity.AddClaim(new Claim("EntityType", user.Entity.EntityType.ToString()));

//            foreach (var right in user.Rights)
//                identity.AddClaim(new Claim("SysAppRight", right.ToString()));

//            var props = new AuthenticationProperties(new Dictionary<string, string>
//            {
//                { "as:client_id", "sicap_portal" },
//                { "userName", user.Username },
//                { "refreshToken", "abc" },
//            });

//            var ticket = new AuthenticationTicket(identity, props);
//            context.Validated(ticket);

//            _userService.Login(user);
            
//            Debug.WriteLine("*** AUTH PROVIDER - GrantRefreshToken() -> VALIDATED " + identity.Name);
//        }

//        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
//        {
//            Debug.WriteLine("*** AUTH PROVIDER - TokenEndpoint()");

//            foreach (var p in context.Properties.Dictionary)
//                context.AdditionalResponseParameters.Add(p.Key, p.Value);

//            return Task.FromResult<object>(null);
//        }
//    }



//    public class Client
//    {
//        [Key]public string Id { get; set; }
//        public string Secret { get; set; }
//        public string Name { get; set; }
//        public ApplicationTypes ApplicationType { get; set; }
//        public bool Active { get; set; }
//        public int RefreshTokenLifeTime { get; set; }
//        public string AllowedOrigin { get; set; }
//    }
    
//    public enum ApplicationTypes
//    {
//        JavaScript = 0,
//        NativeConfidential = 1
//    };


//}