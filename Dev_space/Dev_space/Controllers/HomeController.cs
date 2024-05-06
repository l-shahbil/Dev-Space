using Dev_space.Models;
using Dev_space.Models.AccountViewModels;
using Dev_space.Repository.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Dev_space.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;


        private IRepository<ApplicationUser> _repoUser;
        private IRepository<Friend> _repoFriend;
        private UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger,IRepository<ApplicationUser> repoUser,IRepository<Friend>repoFriend, UserManager<ApplicationUser> userManager) :base(repoUser, repoFriend, userManager)
        {
            _logger = logger;
            _repoUser = repoUser;
            _repoFriend = repoFriend;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()

        {

           await calculateFriends();
            return View();
        }

        public IActionResult GetPostsViewComponente(int _pageNumber , int _pageSize = 20)
        {

            return ViewComponent("GetPosts", new { pageNumber = _pageNumber });
        }


        public async Task<IActionResult> Search(string userName)
        {
            if (!(string.IsNullOrEmpty(userName)))
            {

            var user = await _userManager.GetUserAsync(User);
            ViewBag.wordSearch = userName;
            var listUser = _repoUser.GetAll().Where(u => u.UserName.Contains(userName) || u.Name.Contains(userName)).ToList();
            //in order remove the current user from the list
            if (listUser.Contains(user))
            {
                listUser.Remove(user);
            }
                await calculateFriends();
                return View(listUser);
            }
            await calculateFriends();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}