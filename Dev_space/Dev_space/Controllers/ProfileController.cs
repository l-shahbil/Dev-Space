using Microsoft.AspNetCore.Mvc;

namespace Dev_space.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult profile()
        {
            return View();
        }
    }
}
