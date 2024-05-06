using Dev_space.Models;
using Dev_space.Models.AccountViewModels;
using Dev_space.Repository.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Dev_space.Controllers
{
    [Authorize]
    public class FriendProfileController : BaseController
    {
        private IRepository<ApplicationUser> _repoUser;
        private IRepository<Post> _repoPost;
        private IRepository<Link> _repoLink;
        private IRepository<Friend> _repoFriend;

        public FriendProfileController(IRepository<ApplicationUser>repoUser,IRepository<Post> repoPost,IRepository<Link>repoLink,IRepository<Friend>repoFriend,UserManager<ApplicationUser>userManager) : base(repoUser, repoFriend, userManager)
        {
            _repoUser = repoUser;
            _repoPost = repoPost;
            _repoLink = repoLink;
            _repoFriend = repoFriend;
        }

        public async Task<IActionResult> index(string name)
        {
            var user = _repoUser.SelectOne(u => u.UserName == name);
            if(user != null)
            {
                var listLink = _repoLink.GetAll().Where(u => u.UserId == user.Id);
                ViewBag.Links = listLink;

                var listPost = _repoPost.FindAllItem("Codes", "Imgs", "archives","likes").Where(u => u.User == user).OrderByDescending(p => p.Date);
                ViewBag.listPost = listPost;

                //in order to follwer for friend profile

                //This line is to count the number of people you have followed
                var listFollowHimFriendProfile = _repoUser.FindAllItem("friends").FirstOrDefault(u => u.Id == user.Id);
                ViewBag.followHimFriendProfile = listFollowHimFriendProfile.friends.Count();

                //This line is to count the number of people who followed me
                var listFollowMeFriendProfile = _repoFriend.GetAll().Where(u => u.IdFriend == user.Id);
                ViewBag.followMeFriendProfile = listFollowMeFriendProfile.Count();

                //in order to follower for user the application
                await calculateFriends();
                return View(user);
            }
            return RedirectToAction("Index", "Home");
        }
       
    }
}
