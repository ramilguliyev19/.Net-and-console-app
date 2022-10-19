using Common.Enum;
using DataAccessLayer.Models;
using EduhomeZero.ViewModels.AccountVMs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EduhomeZero.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public IActionResult Register()
        {
            return View();
        }

        public async Task<IActionResult> Register(RegisterVM register)
        {
            if(!ModelState.IsValid)
            {
                return View(register);
            }

            AppUser newUser = new AppUser()
            {
                Firstname = register.Firstname,
                Lastname = register.Lastname,
                Email = register.Email,
                UserName = register.Username
            };

            IdentityResult result = await _userManager.CreateAsync(newUser, register.Password);

            if(!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    return View();
                }
            }

            if((await _userManager.GetUsersInRoleAsync(Enums.Roles.Admin.ToString())).Count == 0)
            {
                await _userManager.AddToRoleAsync(newUser, Enums.Roles.Admin.ToString());
            }else
            {
                await _userManager.AddToRoleAsync(newUser, Enums.Roles.Member.ToString());
            }

            string token = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);

            string route = Url.Action("ConfirmEmail", "Account", new { userId = newUser.Id, token }, HttpContext.Request.Scheme);

            return RedirectToAction(controllerName: "Home", actionName: "Index");
        }
    }
}
