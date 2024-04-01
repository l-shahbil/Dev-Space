using Microsoft.AspNetCore.Mvc;

namespace Dev_space.Controllers
{
    public class NotificationController : Controller
    {
        public IActionResult notification()
        {
            return View();
        }
    }
}
