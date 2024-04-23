using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dev_space.Controllers
{
    [Authorize]
    public class HashtagController : Controller
    {
        public IActionResult hashtag()
        {
            return View();
        }
    }
}
