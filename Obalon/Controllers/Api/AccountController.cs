//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Mvc;
//using System.Web.Http;
//using System.Net.Http;
//using Microsoft.Owin.Security;
//using Microsoft.Owin.Security.Cookies;
//using Obalon.Security;
//using Obalon.Services;

//namespace Obalon.Controllers.Api
//{
//    //[Authorize]
//    //[RoutePrefix(ApiPrefix.Reg + "Account")]            // we make this public because user has not selected a certificate
//    public class AccountController : ApiController
//    {
//        readonly IUserService userService;
//        IAuthenticationManager Authentication { get { return HttpContext.Current.GetOwinContext().Authentication; } }

//        public AccountController(IUserService userService)
//        {
//            this.userService = userService;
//        }

//        [HttpGet]
//        public User GetCurrentUser()
//        {
//            return userService.CurrentUser;
//        }


//        [HttpGet]
//        public string GetCurrentUserName()
//        {
//            // Based on the OWIN authentication, finds the current authenticated username.     
//            return Authentication.User.Identity.Name;
//        }

//        [HttpGet]
//        public bool GetIsLoggedIn()
//        {
//            // Based on the OWIN authentication, tells if the user is authenticated.
//            return Authentication.User.Identity.IsAuthenticated;
//        }

//        [HttpGet]
//        async public Task<IEnumerable<string>> GetCurrentUserRoles()
//        {
//            // Get the userID from the Request context, and pass the ID into the usermanager to get the current user roles.
//            return await Task.Factory.StartNew(() => Enumerable.Empty<string>());
//            //return await UserManager.GetRolesAsync(Request.GetOwinContext().Authentication.User.Identity.GetUserId());
//        }

//        [HttpPost]
//        public async Task<Ihh> Logout()
//        {
//            await userService.Logout();
//            Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
//            return Ok();
//        }
//    }
//}
