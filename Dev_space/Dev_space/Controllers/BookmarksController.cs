using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dev_space.Controllers
{
    [Authorize]
    public class BookmarksController : Controller
    {
        public IActionResult bookmarks()
        {
            return View();
        }
    }
}
