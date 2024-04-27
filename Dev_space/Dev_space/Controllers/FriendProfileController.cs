using Dev_space.Models;
using Dev_space.Models.AccountViewModels;
using Dev_space.Repository.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dev_space.Controllers
{
    [Authorize]
    public class FriendProfileController : Controller
    {
        private IRepository<ApplicationUser> _repoUser;
        private IRepository<Post> _repoPost;
        private IRepository<Link> _repoLink;

        public FriendProfileController(IRepository<ApplicationUser>repoUser,IRepository<Post> repoPost,IRepository<Link>repoLink)
        {
            _repoUser = repoUser;
            _repoPost = repoPost;
            _repoLink = repoLink;
        }

        public IActionResult index(string name)
        {
            var user = _repoUser.SelectOne(u => u.UserName == name);
            if(user != null)
            {
                var listLink = _repoLink.GetAll().Where(u => u.UserId == user.Id);
                ViewBag.Links = listLink;

                var listPost = _repoPost.FindAllItem("Codes", "Imgs").Where(u => u.User == user).OrderByDescending(p => p.Date);
                ViewBag.listPost = listPost;

                return View(user);
            }
            return RedirectToAction("Index", "Home");
        }
       
    }
}
