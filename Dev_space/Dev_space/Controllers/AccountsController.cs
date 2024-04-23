using Dev_space.Models;
using Dev_space.Models.AccountViewModels;
using Dev_space.Repository.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Dev_space.Controllers
{
    [Authorize]
    public class AccountsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManger;
        private readonly SignInManager<ApplicationUser> _singManger;
        private IRepository<Link> _repoLinks;

        public AccountsController(UserManager<ApplicationUser> userManger, SignInManager<ApplicationUser> singManger,IRepository<Link> repoLinks)
        {
            _userManger = userManger;
            _singManger = singManger;
            _repoLinks = repoLinks;
        }
       
        [AllowAnonymous]
        public IActionResult Register()
        {
            
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVeiwModel model)
        {
            ModelState.Remove("NewRegister.Id");
            ModelState.Remove("Users");
            ModelState.Remove("ChangePassword");
            ModelState.Remove("ChangeUserData");
            ModelState.Remove("NewRegister.PhotoProfile");
            ModelState.Remove("NewRegister.Description");
            ModelState.Remove("NewRegister.ImageUser");
            ModelState.Remove("NewRegister.PhotoProfile");
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    Id = model.NewRegister.Id,
                    Name = model.NewRegister.Name,
                    UserName = model.NewRegister.UserName,
                    Email = model.NewRegister.Email,
                    Gender = model.NewRegister.gender,
                    BirthDate=model.NewRegister.BirthDate,
                    Country =model.NewRegister.Country,
                    ImgUser = model.NewRegister.ImageUser,
                    DateRegister = DateTime.Now,
                    ActiveUser = true

                };
                user.Id = Guid.NewGuid().ToString();
                var result =await _userManger.CreateAsync(user, model.NewRegister.Password);
                if (result.Succeeded)
                {
                    Link twitter = new Link
                    {
                        Id = Guid.NewGuid().ToString(),
                        Type = 0,
                        User = user
                    };
                    Link github = new Link
                    {
                        Id = Guid.NewGuid().ToString(),
                        Type = 1,
                        User = user
                    };
                    Link instagram = new Link
                    {
                        Id = Guid.NewGuid().ToString(),
                        Type = 2,
                        User = user
                    };
                    Link behance = new Link
                    {
                        Id = Guid.NewGuid().ToString(),
                        Type = 3,
                        User = user
                    };
                    _repoLinks.AddItem(twitter);
                    _repoLinks.AddItem(github);
                    _repoLinks.AddItem(instagram);
                    _repoLinks.AddItem(behance);
                    return RedirectToAction("Index","Home");
                }
                else
                {

                foreach(var error in result.Errors)
                {
                    if(error.Code == "DuplicateUserName")
                    {
                            TempData["errorUser"] = "User Is Founded";
                    }
                }
                }
                
            }
            return View(model);
        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _singManger.PasswordSignInAsync(model.UserName, model.Password, model.RemmeberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.ErrorLogin = false;
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Logout(LoginViewModel model)
        {
            await _singManger.SignOutAsync();
            return RedirectToAction("Login");
        }
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        public IActionResult CompletaRegisterInfo()
        {
            return View();
        }
        public IActionResult EmailToResetPassword()
        {
            return View();
        }
        public IActionResult RegisterConfirmation()
        {
            return View();
        }
        public IActionResult ResetPassword()
        {
            return View();
        }
    }
}
