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
        private IRepository<ApplicationUser> _repoUser;
        private IRepository<Friend> _repoFriend;
        private IRepository<Post> _repoPost;
        private IRepository<Like> _repoLike;

        public AccountsController(UserManager<ApplicationUser> userManger, SignInManager<ApplicationUser> singManger,IRepository<Link> repoLinks,IRepository<ApplicationUser>repoUser,IRepository<Friend> repoFriend,IRepository<Post> repoPost,IRepository<Like> repoLike)
        {
            _userManger = userManger;
            _singManger = singManger;
            _repoLinks = repoLinks;
            _repoUser = repoUser;
            _repoFriend = repoFriend;
            _repoPost = repoPost;
            _repoLike = repoLike;
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
        public async Task<IActionResult> Follow(string userName, string pageName, string wordSearch)
        {

            var userFollower = _repoUser.SelectOne(u => u.UserName == userName);

            if (userFollower != null)
            {
                var user = await _userManger.GetUserAsync(User);
                Friend friend = new Friend
                {
                    IdFriend = userFollower.Id,
                    User = user,
                    DateFollow = DateTime.Now

                };
                var reFriend = _repoFriend.FindAllItem("User");
                //In order to verify that the user is not following the friend
                if (!reFriend.Any(f => f.IdFriend == friend.IdFriend && f.User == user))
                {
                    _repoFriend.AddItem(friend);

                }
                //the wordSearch for return Action Serach,because it's requierd word search
                if (pageName == "searchPage")
                {
                    return RedirectToAction("Search","Home", new { userName = wordSearch });
                }
                else if (pageName == "ProfilePage")
                {
                    return RedirectToAction("Index", "FriendProfile", new { name = userName });
                }
            }
            return RedirectToAction("Index","Home");
        }
        public async Task<IActionResult> unFollow(string userName, string pageName, string wordSearch)
        {
            //the wordSearch for return Action Serach,because it's requierd word search

            var userUnFollower = _repoUser.SelectOne(u => u.UserName == userName);

            if (userUnFollower != null)
            {
                var user = await _userManger.GetUserAsync(User);
                var reFriend = _repoFriend.FindAllItem("User");
                var friend = reFriend.FirstOrDefault(f => f.IdFriend == userUnFollower.Id && f.User == user);
                //In order to verify that the user is not following the friend
                if (friend != null)
                {
                    _repoFriend.RemoveItem(friend);

                }
            }
            if (pageName == "searchPage")
            {
                return RedirectToAction("Search","Home", new { userName = wordSearch });
            }
            else if (pageName == "ProfilePage")
            {
                return RedirectToAction("Index", "FriendProfile", new { name = userName });
            }
            return RedirectToAction("Index","Home");

        }
        public async Task<IActionResult> Like(string postID, string pageAction, string userFriend)
        {
            if (pageAction == "Home")
            {
                await likeFunction(postID);
                return RedirectToAction("Index", "Home");
            }
            else if (pageAction == "Profile")
            {
                await likeFunction(postID);
                return RedirectToAction("Index", "Profile");
            }
            else if (pageAction == "FriendProfile")
            {
                await likeFunction(postID);
                return RedirectToAction("index", "FriendProfile", new { name = userFriend });
            }
            else if (pageAction == "ShowBookMarks")
            {
                await likeFunction(postID);
                return RedirectToAction("ShowBookMarks", "Bookmarks");
            }
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> DisLike(string likeId, string pageAction, string userFriend)
        {
            if (pageAction == "Home")
            {
                await DisLikeFunction(likeId);
                return RedirectToAction("Index", "Home");
            }
            else if (pageAction == "Profile")
            {
                await DisLikeFunction(likeId);
                return RedirectToAction("Index", "Profile");
            }
            else if (pageAction == "FriendProfile")
            {
                await DisLikeFunction(likeId);
                return RedirectToAction("index", "FriendProfile", new { name = userFriend });
            }
            else if (pageAction == "ShowBookMarks")
            {
                await DisLikeFunction(likeId);
                return RedirectToAction("ShowBookMarks", "Bookmarks");
            }
            return RedirectToAction("Index", "Home");
        }
        public async Task likeFunction(string postID)
        {
            if (!string.IsNullOrEmpty(postID))
            {
                var user = await _userManger.GetUserAsync(User);
                if (user != null)
                {
                    var post = _repoPost.FindById(postID);
                    if (post != null)
                    {
                        var like = new Like
                        {
                            Id = Guid.NewGuid().ToString(),
                            User = user,
                            post = post,
                            DateTime = DateTime.Now
                        };
                        _repoLike.AddItem(like);
                    }
                }

            }
        }
        public async Task DisLikeFunction(string LikeId)
        {
            if (!string.IsNullOrEmpty(LikeId))
            {
                var disLike = _repoLike.FindById(LikeId);
                if (await _userManger.GetUserAsync(User) != null)
                {
                    if (disLike != null)
                    {
                        _repoLike.RemoveItem(disLike);
                    }
                }
            }
        }
    }
}
