using Microsoft.AspNetCore.Mvc;

namespace Dev_space.Controllers
{
    public class BookmarksController : Controller
    {
        public IActionResult bookmarks()
        {
            return View();
        }
    }
}
