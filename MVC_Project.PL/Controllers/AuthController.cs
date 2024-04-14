using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_Project.DAL.Models;
using MVC_Project.PL.ViewModels.User;
using System.Threading.Tasks;

namespace MVC_Project.PL.Controllers
{
    public class AuthController : Controller
    {
		private readonly UserManager<ApplicationUser> userManager;
		private readonly SignInManager<ApplicationUser> signInManager;

		public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
			this.userManager = userManager;
			this.signInManager = signInManager;
		}


        #region Sigh Up

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(model.UserName);
                if(user is null)
                {
					ModelState.AddModelError("UserName", "UserName is already taken");
					return View(model);
				}

                user = new ApplicationUser()
                {
					UserName = model.UserName,
					Email = model.Email,
					FName = model.FName,
					LName = model.LName
				};

                var result = await userManager.CreateAsync(user, model.Password);

				if(result.Succeeded)
                    return RedirectToAction(nameof(SignIn));
            }


			return View(model);
		}
        #endregion
    }
}
