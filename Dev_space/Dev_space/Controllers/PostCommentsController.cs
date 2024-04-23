using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dev_space.Controllers
{
    [Authorize]
    public class PostCommentsController : Controller
    {
        public IActionResult postComments()
        {
            return View();
        }
    }
}
