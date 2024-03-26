using Microsoft.AspNetCore.Mvc;

namespace Dev_space.Controllers
{
    public class PostCommentsController : Controller
    {
        public IActionResult postComments()
        {
            return View();
        }
    }
}
