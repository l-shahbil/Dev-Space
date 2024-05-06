using Dev_space.Data;
using Dev_space.Models;
using Dev_space.Models.AccountViewModels;
using Dev_space.Repository.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;

namespace Dev_space.Controllers
{
    [Authorize]
    public class ProfileController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManger;
        private IRepository<Link> _repositoryLink;
        private  IHostingEnvironment _host;
        private  IRepository<Post> _repoPost;
        private IRepository<Friend> _repoFriend;
        private IRepository<ApplicationUser> _repoUser;

        public ProfileController(UserManager<ApplicationUser>userManager,IRepository<Link> repositoryLink, IHostingEnvironment host,IRepository<Post>repoPost,IRepository<Friend> repoFriend,IRepository<ApplicationUser> repoUser) : base(repoUser, repoFriend, userManager)
        {
            _userManger = userManager;
            _repositoryLink = repositoryLink;
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

            var listPost = _repoPost.FindAllItem("Codes", "Imgs", "archives", "likes").Where(u => u.User == user).OrderByDescending(p => p.Date);
            ViewBag.listPost = listPost;


            await calculateFriends();
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
                var user = await _userManger.FindByIdAsync(model.ChangeUserData.Id);
                if(user != null)
                {

                string ImgProfileName = string.Empty;
                string ImgCoverName = string.Empty;


                if (model.ChangeUserData.ImgProfile != null)
                {
                    if(string.IsNullOrEmpty(user.ImgUser))
                    {

                        string MyUplod = Path.Combine(_host.WebRootPath, "Images/Personal");
                        string fileExtention = Path.GetExtension(model.ChangeUserData.ImgProfile.FileName);
                        ImgProfileName = $"{Guid.NewGuid()}{fileExtention}";
                        string fullPath = Path.Combine(MyUplod, ImgProfileName);
                        model.ChangeUserData.ImgProfile.CopyTo(new FileStream(fullPath, FileMode.Create));

                        user.ImgUser = ImgProfileName;
                    }
                    else
                    {
                        string MyUplod = Path.Combine(_host.WebRootPath, "Images/Personal");
                        string fileExtention = Path.GetExtension(model.ChangeUserData.ImgProfile.FileName);
                        ImgProfileName = $"{Guid.NewGuid()}{fileExtention}";
                        string fullPath = Path.Combine(MyUplod, ImgProfileName);
                        model.ChangeUserData.ImgProfile.CopyTo(new FileStream(fullPath, FileMode.Create));

                        //for delete old img
                        string oldPath = Path.Combine(MyUplod,user.ImgUser);
                        System.IO.File.Delete(oldPath);


                        user.ImgUser = ImgProfileName;
                    }
                    
                }
                if (model.ChangeUserData.ImgCover != null)
                {
                    if (string.IsNullOrEmpty(user.CoverImgUser))
                    {

                        string MyUplod = Path.Combine(_host.WebRootPath, "Images/Personal");
                        string fileExtention = Path.GetExtension(model.ChangeUserData.ImgCover.FileName);
                        ImgCoverName = $"{Guid.NewGuid()}{fileExtention}";
                        string fullPath = Path.Combine(MyUplod, ImgCoverName);
                        model.ChangeUserData.ImgCover.CopyTo(new FileStream(fullPath, FileMode.Create));

                        user.CoverImgUser = ImgCoverName;
                    }
                    else
                    {
                        string MyUplod = Path.Combine(_host.WebRootPath, "Images/Personal");
                        string fileExtention = Path.GetExtension(model.ChangeUserData.ImgCover.FileName);
                        ImgCoverName = $"{Guid.NewGuid()}{fileExtention}";
                        string fullPath = Path.Combine(MyUplod, ImgCoverName);
                        model.ChangeUserData.ImgCover.CopyTo(new FileStream(fullPath, FileMode.Create));

                        //for delete old img
                        string oldPath = Path.Combine(MyUplod, user.CoverImgUser);
                        System.IO.File.Delete(oldPath);

                        user.CoverImgUser = ImgCoverName;
                    }
                }



                user.Name = model.ChangeUserData.Name;
                user.UserName = model.ChangeUserData.UserName;
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
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePasswrod(RegisterVeiwModel model)
        {
            ModelState.Remove("Users");
            ModelState.Remove("NewRegister");
            ModelState.Remove("ChangeUserData");
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
