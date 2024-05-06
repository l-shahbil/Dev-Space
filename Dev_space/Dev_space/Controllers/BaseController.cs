using Dev_space.Models;
using Dev_space.Models.AccountViewModels;
using Dev_space.Repository.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Dev_space.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        private IRepository<ApplicationUser> _repoUser;
        private IRepository<Friend> _repoFriend;
        private UserManager<ApplicationUser> _userManager;

        public BaseController(IRepository<ApplicationUser> repoUser, IRepository<Friend> repoFriend, UserManager<ApplicationUser> userManager)
        {
            _repoUser = repoUser;
            _repoFriend = repoFriend;
            _userManager = userManager;
        }
        public async Task calculateFriends()
        {
           
                var user = await _userManager.GetUserAsync(User);
                //This line is to count the number of people you have followed
                var listFollowHim = _repoUser.FindAllItem("friends").FirstOrDefault(u => u.Id == user.Id);
                ViewBag.followHim = listFollowHim.friends.Count();

                //This line is to count the number of people who followed me
                var listFollowMe = _repoFriend.GetAll().Where(u => u.IdFriend == user.Id);
                ViewBag.followMe = listFollowMe.Count();
            
            
        }
    }
}
