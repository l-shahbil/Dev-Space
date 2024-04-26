using Dev_space.Models;
using Dev_space.Models.AccountViewModels;
using Dev_space.Repository.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Dev_space.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IHostingEnvironment _host;
        private IRepository<ApplicationUser> _repoUser;
        private IRepository<Friend> _repoFriend;
        private  IRepository<Post> _repoPost;
        private IRepository<Code> _repoCode;
        private IRepository<Img> _repoImg;
        private UserManager<ApplicationUser> _userManger;

        public HomeController(ILogger<HomeController> logger, IHostingEnvironment host, IRepository<ApplicationUser> repoUser,IRepository<Friend>repoFriend,IRepository<Post> repoPost,IRepository<Code> repoCode,IRepository<Img> repoImg, UserManager<ApplicationUser> userManger)
        {
            _logger = logger;
            _host = host;
            _repoUser = repoUser;
            _repoFriend = repoFriend;
            _repoPost = repoPost;
            _repoCode = repoCode;
            _repoImg = repoImg;
            _userManger = userManger;
        }

        public async Task<IActionResult> Index()

        {
            var user = await _userManger.GetUserAsync(User);
            //This line is to count the number of people you have followed
            var listFollowHim = _repoUser.FindAllItem("friends").FirstOrDefault(u => u.Id == user.Id);
            ViewBag.followHim = listFollowHim.friends.Count();

            //This line is to count the number of people who followed me
            var listFollowMe = _repoFriend.GetAll().Where(u => u.IdFriend == user.Id);
            ViewBag.followMe = listFollowMe.Count();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Post(Post p)
        {
            if(p.Text !=null || p.Img!=null || p.Code != null)
            {

                var user = await _userManger.GetUserAsync(User);
                var post = new Post();
                if (p.Text != null)
                {


                    post.Id = Guid.NewGuid().ToString();
                    post.Text = p.Text;
                    post.Date = DateTime.Now;
                    post.User = user;

                    
                }
                else
                {
                    post.Id = Guid.NewGuid().ToString();
                    post.Date = DateTime.Now;
                    post.User = user;

                    
                }
                _repoPost.AddItem(post);
                if (p.Img != null)
                {
                    string myUpload = Path.Combine(_host.WebRootPath, "Images/Post");
                    string fileExtention = Path.GetExtension(p.Img.FileName);
                    string fileName = $"{Guid.NewGuid()}{fileExtention}";
                    string fullPath = Path.Combine(myUpload,fileName );
                    p.Img.CopyTo(new FileStream(fullPath, FileMode.Create));
                    var Img = new Img
                    {
                        Id = Guid.NewGuid().ToString(),
                        pathImg = fileName,
                        post = post
                    };
                    _repoImg.AddItem(Img);
                }
                if(p.Code != null)
                    {
                        var code = new Code
                        {
                            Id = Guid.NewGuid().ToString(),
                            CodeText = p.Code,
                            post = post
                        };
                    _repoCode.AddItem(code);
                    }
                
            }
            
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> DeletePost(string id)
        {
            Post post = _repoPost.FindById(id);
            if (post != null)
            {
                var user = await _userManger.GetUserAsync(User);
                if(user == post.User)
                {
                    _repoPost.RemoveItem(post);

                }
            }
            return RedirectToAction("Index", "Profile");
        }
        
        public async Task<IActionResult> Search(string userName)
        {
            if (!(string.IsNullOrEmpty(userName)))
            {

            var user = await _userManger.GetUserAsync(User);
            ViewBag.wordSearch = userName;
            var listUser = _repoUser.GetAll().Where(u => u.UserName.Contains(userName)).ToList();
            //in order remove the current user from the list
            if (listUser.Contains(user))
            {
                listUser.Remove(user);
            }
            return View(listUser);
            }
            return View();
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
                    return RedirectToAction("Search", new { userName = wordSearch });
                }
                else if (pageName == "ProfilePage")
                {
                    return RedirectToAction("Index", "FriendProfile", new { name = userName });
                }
            }
               return RedirectToAction("Index");
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
                return RedirectToAction("Search", new { userName = wordSearch });
            }
            else if (pageName == "ProfilePage")
            {
                return RedirectToAction("Index", "FriendProfile", new { name = userName });
            }
            return RedirectToAction("Index");

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}