using Dev_space.Models;
using Dev_space.Models.AccountViewModels;
using Dev_space.Repository.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dev_space.ViewComponents
{
    public class GetPostsViewComponent:ViewComponent
    {
        private  UserManager<ApplicationUser> _userManger;
        private IRepository<Post> _repoPost;
        private  IHttpContextAccessor _httpContextAccessor;

        public GetPostsViewComponent(UserManager<ApplicationUser>userManger,IRepository<Post>repoPost, IHttpContextAccessor httpContextAccessor)
        {
            _userManger = userManger;
            _repoPost = repoPost;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<IViewComponentResult> InvokeAsync(int pageNumber = 1 ,int pageSize=20 )
        {
            var Crruentuser = _httpContextAccessor.HttpContext.User;
            var user = await _userManger.GetUserAsync(Crruentuser);
            var userWithFriends = _userManger.Users.Include(u => u.friends).FirstOrDefault(u => u.Id ==user.Id);
            var listFriends = userWithFriends.friends;

            var posts = _repoPost.FindAllItem("User","Codes","Imgs");
            var postHisFriends = listFriends.SelectMany(friend => posts.Where(p => p.User.Id == friend.IdFriend)).ToList();

            var OrderPosts = postHisFriends.OrderByDescending(e => e.Date).Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return View(OrderPosts);
        }
    }
}
