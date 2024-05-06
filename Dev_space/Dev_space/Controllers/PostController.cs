using Dev_space.Models;
using Dev_space.Models.AccountViewModels;
using Dev_space.Repository.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Dev_space.Controllers
{
    public class PostController : Controller
    {
        private IHostingEnvironment _host;
  
        private IRepository<Post> _repoPost;
        private IRepository<Code> _repoCode;
        private IRepository<Img> _repoImg;
        private UserManager<ApplicationUser> _userManger;
        public PostController(IHostingEnvironment host, IRepository<Post> repoPost, IRepository<Code> repoCode, IRepository<Img> repoImg, UserManager<ApplicationUser> userManager)
        {
            _host = host;
            _repoPost = repoPost;
            _repoCode = repoCode;
            _repoImg = repoImg;
            _userManger = userManager;
        }
        //[HttpGet]
        //public IActionResult viewPost()
        //{
        //    return View();
        //}
        //This Action for Add Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Post(Post p)
        {
            if (p.Text != null || p.Img != null || p.Code != null)
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
                    string fullPath = Path.Combine(myUpload, fileName);
                    p.Img.CopyTo(new FileStream(fullPath, FileMode.Create));
                    var Img = new Img
                    {
                        Id = Guid.NewGuid().ToString(),
                        pathImg = fileName,
                        post = post
                    };
                    _repoImg.AddItem(Img);
                }
                if (p.Code != null)
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

            return RedirectToAction("Index","Home");
        }
        [HttpGet]
        public async Task<IActionResult> DeletePost(string id)
        {
            Post post = _repoPost.FindById(id);
            var user = await _userManger.GetUserAsync(User);
            if (post != null && user == post.User)
            {
                _repoPost.RemoveItem(post);

            }
            return RedirectToAction("Index", "Profile");
        }
        [HttpPost]
        public async Task<IActionResult> EditPost(string idPost, string text, string code)
        {

            var user = await _userManger.GetUserAsync(User);
            var post = _repoPost.FindAllItem("Codes", "Imgs").FirstOrDefault(p => p.Id == idPost);
            var codePost = post.Codes.FirstOrDefault();
            if (post != null && post.User == user)
            {
                var oldId = post.Id;
                var oldDate = post.Date;
                if (!string.IsNullOrEmpty(idPost) && !string.IsNullOrEmpty(code))
                {
                    //remove the past code and create new code and added post
                    if (post.Codes.Count() != 0)
                    {
                        //update code
                        codePost.CodeText = code;
                        _repoCode.UpdateItem(codePost);

                        //update text 
                        post.Text = text;
                        _repoPost.UpdateItem(post);
                    }
                    //create new code and add post
                    else if (post.Codes.Count() == 0)
                    {
                        //update text
                        post.Text = text;
                        _repoPost.UpdateItem(post);

                        var NewCode = new Code
                        {
                            Id = Guid.NewGuid().ToString(),
                            CodeText = code,
                            post = post

                        };
                        _repoCode.AddItem(NewCode);

                    }
                }
                else if (string.IsNullOrEmpty(code) && string.IsNullOrEmpty(text))
                {
                    //the img is exist
                    if (post.Imgs.Count() != 0)
                    {
                        if (post.Codes.Count() != 0)
                        {
                            _repoCode.RemoveItem(codePost);
                        }
                        post.Text = String.Empty;
                        _repoPost.UpdateItem(post);
                    }
                    //the img not exist
                    else if (post.Imgs.Count() == 0)
                    {
                        _repoPost.RemoveItem(post);
                    }

                }
                else if (!string.IsNullOrEmpty(code) || !string.IsNullOrEmpty(text))
                {
                    if (!string.IsNullOrEmpty(text))
                    {
                        //Update post
                        post.Text = text;
                        _repoPost.UpdateItem(post);

                        //if user send code null but the code already exist
                        if (post.Codes.Count() != 0)
                        {
                            _repoCode.RemoveItem(codePost);
                        }
                    }
                    else if (!string.IsNullOrEmpty(code))
                    {
                        post.Text = String.Empty;
                        if (post.Codes.Count() != 0)
                        {
                            codePost.CodeText = code;
                            _repoCode.UpdateItem(codePost);
                        }
                        else
                        {
                            var newCode = new Code
                            {
                                Id = Guid.NewGuid().ToString(),
                                CodeText = code,
                                post = post
                            };
                            _repoCode.AddItem(newCode);
                        }
                    }

                }
            }
            return RedirectToAction("Index", "Profile");
        }

    }
}
