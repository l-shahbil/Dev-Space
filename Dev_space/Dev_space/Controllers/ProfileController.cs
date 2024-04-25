using Dev_space.Data;
using Dev_space.Models;
using Dev_space.Models.AccountViewModels;
using Dev_space.Repository.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Microsoft.EntityFrameworkCore;

namespace Dev_space.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManger;
        private IRepository<Link> _repositoryLink;
        private  AppDbContext _context;
        private  IHostingEnvironment _host;
        private  IRepository<Post> _repoPost;
        private IRepository<Friend> _repoFriend;
        private IRepository<ApplicationUser> _repoUser;

        public ProfileController(UserManager<ApplicationUser>userManger,IRepository<Link> repositoryLink,AppDbContext context, IHostingEnvironment host,IRepository<Post>repoPost,IRepository<Friend> repoFriend,IRepository<ApplicationUser> repoUser)
        {
            _userManger = userManger;
            _repositoryLink = repositoryLink;
            _context = context;
            _host = host;
            _repoPost = repoPost;
            _repoFriend = repoFriend;
            _repoUser = repoUser;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManger.GetUserAsync(User);
            var listLink = _repositoryLink.GetAll().Where(u => u.UserId== user.Id);
            ViewBag.MyLink = listLink;

            var listPost = _repoPost.FindAllItem("Codes", "Imgs").Where(u => u.User == user);
            ViewBag.listPost = listPost;

            var listFollowMe = _repoUser.FindAllItem("friends").Where(u => u.Id == user.Id);
            ViewBag.followMe = listFollowMe.Count();

            //var listFollowers = _repoFriend.GetAll().Where(u => u.IdFriend == user.Id);
            //ViewBag.followers = listFollowers.Count();

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateUserData(RegisterVeiwModel model)
        {
            ModelState.Remove("NewRegister");
            ModelState.Remove("ChangePassword");
            ModelState.Remove("Users");

            ModelState.Remove("ChangeUserData.LinkBehance");
            ModelState.Remove("ChangeUserData.LinkTwitter");
            ModelState.Remove("ChangeUserData.LinkGithub");
            ModelState.Remove("ChangeUserData.LinkInstagram");

            ModelState.Remove("ChangeUserData.Discription");
            ModelState.Remove("ChangeUserData.ImgProfile");
            ModelState.Remove("ChangeUserData.ImgCover");

            if (ModelState.IsValid)
            {
                string ImgProfileName = string.Empty;
                string ImgCoverName = string.Empty;
                

                if(model.ChangeUserData.ImgProfile != null)
                {
                    string MyUplod = Path.Combine(_host.WebRootPath, "Images/Personal");
                    ImgProfileName = model.ChangeUserData.ImgProfile.FileName;
                    string fullPath = Path.Combine(MyUplod, ImgProfileName);
                    model.ChangeUserData.ImgProfile.CopyTo(new FileStream(fullPath, FileMode.Create));
                    
                }
                if(model.ChangeUserData.ImgCover != null)
                {
                    string MyUplod = Path.Combine(_host.WebRootPath, "Images/Personal");
                    ImgCoverName = model.ChangeUserData.ImgCover.FileName;
                    string fullPath = Path.Combine(MyUplod, ImgCoverName);
                    model.ChangeUserData.ImgCover.CopyTo(new FileStream(fullPath, FileMode.Create));
                }
                var user = await _userManger.FindByIdAsync(model.ChangeUserData.Id);
                user.Id = model.ChangeUserData.Id;
                user.Name = model.ChangeUserData.Name;
                user.UserName = model.ChangeUserData.UserName;
                user.ImgUser = ImgProfileName;
                user.CoverImgUser = ImgCoverName;
                user.Description = model.ChangeUserData.Discription;
              
                
                
                var result = await _userManger.UpdateAsync(user);
                if (result.Succeeded)
                {
                    var listLink = _repositoryLink.GetAll().Where(u => u.UserId == user.Id);
                    foreach(var link in listLink)
                    {
                        if(link.Type == 0 && model.ChangeUserData.LinkTwitter !=null)
                        {
                            link.URL = model.ChangeUserData.LinkTwitter;

                        }
                        else if(link.Type == 1 && model.ChangeUserData.LinkGithub != null)
                        {
                            link.URL = model.ChangeUserData.LinkGithub;
                        }
                        else if(link.Type == 2 && model.ChangeUserData.LinkBehance != null)
                        {
                            link.URL = model.ChangeUserData.LinkBehance;
                        }
                        else if(link.Type == 3 && model.ChangeUserData.LinkInstagram != null)
                        {
                            link.URL = model.ChangeUserData.LinkInstagram;
                        }

                        _repositoryLink.UpdateItem(link);
                    }
                }

            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePasswrod(RegisterVeiwModel model)
        {
            if (ModelState.IsValid)
            {

            var user = await _userManger.FindByIdAsync(model.ChangePassword.id);
            if (user != null)
            {
                await _userManger.RemovePasswordAsync(user);
                var addPassword = await _userManger.AddPasswordAsync(user, model.ChangePassword.NewPassword);
            }
            }
                return RedirectToAction("Index");
        }
    }
}
