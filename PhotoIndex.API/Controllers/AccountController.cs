using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

using AutoMapper;

using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

using PhotoIndex.Model;
using PhotoIndex.Service;
using PhotoIndex.API.ViewModels;

namespace PhotoIndex.API.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IUserService userService;
        private readonly UserManager<ApplicationUser> userManager;

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().Authentication;
            }
        }

        public AccountController(IUserService userService, UserManager<ApplicationUser> userManager)
        {
            this.userService = userService;
            this.userManager = userManager;

            //Todo: This needs to be moved from here.
            this.userManager.UserValidator = new UserValidator<ApplicationUser>(userManager)
            {
                AllowOnlyAlphanumericUserNames = false
            };
        }

        [HttpPost]
        [OverrideAuthorization]
        public async Task<IHttpActionResult> Post(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ApplicationUser user = new ApplicationUser();
                    Mapper.Map(viewModel, user);

                    var identityResult = await userManager.CreateAsync(user, viewModel.Password);

                    if (identityResult.Succeeded)
                    {
                        userManager.AddToRole(user.Id, "Member");
                        return Ok();
                    }
                    else
                    {
                        foreach (var error in identityResult.Errors)
                        {
                            ModelState.AddModelError(error,error);
                        }

                        return BadRequest(ModelState);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        #region Private methods
        private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            try
            {
                AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
                var identity = await userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Private methods
    }
}