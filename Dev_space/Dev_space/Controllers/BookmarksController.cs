using Dev_space.Models;
using Dev_space.Models.AccountViewModels;
using Dev_space.Repository.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Dev_space.Controllers
{
    [Authorize]
    public class BookmarksController : BaseController
    {
        private UserManager<ApplicationUser> _userManager;
        private IRepository<ApplicationUser> _repoUser;
        private IRepository<Post> _repoPost;
        private IRepository<Friend> _repoFriend;
        private IRepository<Archive> _repoArchive;

        public BookmarksController(UserManager<ApplicationUser>userManager, IRepository<ApplicationUser> reoUser, IRepository<Post> reoPost,IRepository<Friend> repoFriend,IRepository<Archive> repoArchive):base(reoUser,repoFriend,userManager)
        {
            _userManager = userManager;
            _repoUser = reoUser;
            _repoPost = reoPost;
            _repoFriend = repoFriend;
            _repoArchive = repoArchive;
        }
        public async Task<IActionResult> ShowBookMarks()
        {
            var user = await _userManager.GetUserAsync(User);
            //Fetch the post is archived
            var archivedPosts = _repoArchive.FindAllItem("Post", "User", "Post.User","Post.Codes","Post.Imgs","Post.archives","Post.likes")
                .Where(a => a.User == user)
                .OrderByDescending(a => a.dateAdded)
                .Select(a => a.Post);

            await calculateFriends();
            return View(archivedPosts);
        }

        public async Task<IActionResult> addBookMarks(string postID,string pageAction,string userFriend)
        {
            
            if(pageAction == "Home")
            {
                await addBookmark(postID);
                return RedirectToAction("Index", "Home");
            }
            else if (pageAction == "Profile")
            {
                await addBookmark(postID);
                return RedirectToAction("Index", "Profile");
            }
            else if (pageAction == "FriendProfile")
            {
                await addBookmark(postID);
                return RedirectToAction("index", "FriendProfile",new { name = userFriend });
            }
           
                return RedirectToAction("Index","Home");
        }
        public async Task<IActionResult> DeleteBookMarks(string archiveID,string pageAction,string userFriend)
        {
            if(pageAction == "Home")
            {
                await removeBookmark(archiveID);
                return RedirectToAction("Index", "Home");
            }
             else if(pageAction == "Profile")
            {
                await removeBookmark(archiveID);
                return RedirectToAction("Index", "Profile");
            }
            else if(pageAction == "FriendProfile")
            {
                await removeBookmark(archiveID);
                return RedirectToAction("index", "FriendProfile", new { name = userFriend });
            }
            else if(pageAction == "ShowBookMarks")
            {
                await removeBookmark(archiveID);
                return RedirectToAction("ShowBookMarks", "Bookmarks");
            }
            return RedirectToAction("Index", "Home");

        }


        public async Task addBookmark(string postID)
        {
            if (!string.IsNullOrEmpty(postID))
            {
                var user = await _userManager.GetUserAsync(User);
                if(user != null)
                {
                    var post = _repoPost.FindById(postID);
                    if (post != null)
                    {
                        var archive = new Archive
                        {
                            Id = Guid.NewGuid().ToString(),
                            User = user,
                            Post = post,
                            dateAdded = DateTime.Now
                        };
                        _repoArchive.AddItem(archive);
                    }
                }

            }
        }
        public async Task removeBookmark(string archiveID)
        {
            if (!string.IsNullOrEmpty(archiveID))
            {
                var archive = _repoArchive.FindById(archiveID);
                if(await _userManager.GetUserAsync(User) != null)
                {
                    if (archive != null)
                    {
                        _repoArchive.RemoveItem(archive);
                    }
                }
            }
        }
    }
}
